using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/// 사용자 인터페이스와 비동기 작업
/// - 동기 파일 복사는 복사하는 도중에 다른 작업을 할 수 없음(여기서는 Cancel 버튼을 눌러 반응확인)
/// - 비동기 파일 복사는 복사하는 도중에 다른 작업을 할 수 있음
/// 
namespace AsyncFileIOWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            btnSyncCopy.Enabled = false;
            long totalCopied = 0;

            using(FileStream fromStream = new FileStream(FromPath, FileMode.Open))
            {
                using(FileStream toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int nRead = 0;
                    while((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;

                        // 프로그레스바에 현재 파일 복사 상태 표시
                        pbCopy.Value = (int)(((double)totalCopied / (double)fromStream.Length)*pbCopy.Maximum);
                    }
                }
            }

            btnSyncCopy.Enabled = true;
            return totalCopied;
        }

        private long CopySync(string FromPath, string ToPath)
        {
            btnAsyncCopy.Enabled = false;
            long totalCopied = 0;

            using (FileStream fromStream = new FileStream(FromPath, FileMode.Open))
            {
                using(FileStream toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[(1024 * 1024)];
                    int nRead = 0;
                    while((nRead = fromStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        toStream.Write(buffer, 0, nRead);
                        totalCopied += nRead;

                        pbCopy.Value = (int)(((double)totalCopied / (double)fromStream.Length) * pbCopy.Maximum);
                    }
                }
            }

            btnAsyncCopy.Enabled = true;
            return totalCopied;
        }

        private void btnFindSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            if(dig.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = dig.FileName;
            }
        }

        private void btnFindTarget_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            if(dig.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = dig.FileName;
            }
        }

        private async void btnAsyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyAsync(txtSource.Text, txtTarget.Text);
        }

        private void btnSyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = CopySync(txtSource.Text, txtTarget.Text);
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI 반응 테스트 성공.");
        }
    }
}
