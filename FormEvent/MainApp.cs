using System;
using System.Windows.Forms;

/// Form에 정의된 이벤트와 이벤트 처리기 연결하기
/// - Form 클래스는 운영체제가 보내는 메시지 중 일부에 대해 이벤트를 구현하고 있다.
///     - Form 인스턴스(윈도우 위)에서 마우스 왼쪽 버튼을 누르면 WM_LBUTTONDOWN 메시지가 Form 객체로 전달되고,
///     Form 객체는 이에 대해 MouseDown 이벤트를 발생시킨다.
/// 
/// - MouseEventHandler 대리자의 선언 => public delegate void MouseEventHandler(object sender, MouseEventHandler e);
/// - MouseDown 이벤트의 선언 => public event MouseEventHandler MouseDown; (대리자, 이벤트는 대리자를 기반으로 선언되어 있다)
///     - 이벤트 처리기가 어떤 매개변수를 가져야 하는지, 그리고 어떤 형식을 반환해야 하는지 알 수 있다.
///     - 첫 번째 매개변수 sender : sender는 이벤트가 발생한 객체를 가리킨다. Form 클래스의 이벤트 처리기인 경우 sender는 Form 객체 자신이다.
///     만약 Button 클래스의 이벤트 처리기 였다면 Button 객체이다.
///     - 두 번재 매개변수 MouseEventArgs 형식인데 프로퍼티들을 제공함으로써 마우스 이벤트의 상세 정보를 제공한다.
///         - Button    : 마우스의 어떤 버튼(왼쪽, 오른쪽 또는 가운데)에서 이벤트가 발생했는지를 나타낸다.
///         - Clicks    : 마우스의 버튼을 클릭한 횟수를 나타낸다. 사용자가 더블 클릭했을 때만 어떤 기능을 수행하고 싶다면 이 값이 2일 경우를 확인하면 된다.
///         - Delta     : 마우스 휠의 회전 방향과 회전한 거리를 나타낸다.
///         - X         : 마우스 이벤트가 발생한 폼 또는 컨트롤상의x(가로) 좌표를 나타낸다.
///         - Y         : 마우스 이벤트가 발생한 폼 또는 컨트롤상의y(세로) 좌표를 나타낸다.
namespace FormEvent
{
    class MainApp : Form
    {
        public void MyMouseHandler(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Sender : {((Form)sender).Text}");
            Console.WriteLine($"X:{e.X}, Y:{e.Y}");
            Console.WriteLine($"Button:{e.Button}, Clicks:{e.Clicks}");
            Console.WriteLine();
        }

        public MainApp(string title)
        {
            this.Text = title;
            this.MouseDown += new MouseEventHandler(MyMouseHandler);
        }
        static void Main(string[] args)
        {
            Application.Run(new MainApp("Mouse Event Test"));
        }
    }
}

