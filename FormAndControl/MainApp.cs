using System;
using System.Windows.Forms;

/// Form 위에 컨트롤 올리기
/// - 사용자 인터페이스는 응용 프로그램과 사용자가 대화를 하는 창구이다.
/// - 윈도우 OS는 사용자 인터페이스를 위해 메뉴, 콤보박스, 리스트뷰, 버튼, 텍스트박스 등과 같은 표준 컨트롤을 제공한다.
///     - .NET의 WinForm은 이들 표준 컨트롤을 아주 간편하게 창 위에 올릴 수 있도록 잘 포장해뒀다.
///     - 큰트롤들을 제어하는 데 필요한 각종 메소드와 프로퍼티, 이벤트들이 잘 정리되어 있다.
/// 
/// 컨트롤 사용법
/// 1. 컨트롤의 인스턴스 생성
/// 2. 컨트롤의 프로퍼티에 값 지정
/// 3. 컨트롤의 이벤트에 이벤트 처리기 등록
/// 4. 폼에 컨트롤 추가
/// 
namespace FormAndControl
{
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            // 1. 컨트롤의 인스턴스 생성
            Button button = new Button();

            // 2. 컨트롤의 프로퍼티에 값 지정
            button.Text = "Click Me!";
            button.Left = 100;
            button.Top = 50;

            // 3. 컨트롤의 이벤트에 이벤트 처리기 등록
            button.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show("딸깍!");
            };

            MainApp form = new MainApp();
            form.Text = "Form & Control";
            form.Height = 150;

            // 4. 폼에 컨트롤 추가
            form.Controls.Add(button);

            Application.Run(form);
        }
    }
}

