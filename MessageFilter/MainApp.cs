using System;
using System.Windows.Forms;

/// 메시지 필터링
/// - 윈도우 기반의 응용 프로그램들은 갑자기 일어나는 사전(이벤트:Event)에 반응해서 코드가 실행되는 이른바 이벤트 기반 방식으로 만들어진다.
/// - 사용자가 마우스나 키보드 같은 하드웨어를 제어 -> 인터럽트 발생 -> 인터럽트를 윈도우OS 받는다 -> 인터럽트를 바탕으로 윈도우 메시지 생성(이벤트) -> 응용 프로그램이 메세지를 받아 처리
/// - 윈도우 메시지는 종류가 매우 다양 (시스템에 정의된 메시지, 응용 프로그램 자체적으로 정의된 메시지)
/// - Application 클래스는 관심있는 메시지만 걸러낼 수 있는 메시지 필터링 기능을 갖고 있다.
/// - 윈도두OS에서 정의하고 있는 메시지는 식별 번호(ID)가 붙여져 있다.
/// 
/// 사용법
/// - IMessageFilter 인터페이스를 구현한 파생 클래스 정의
/// - Application.AddMessageFilter() 메소드에 메시지 필터(IMessageFilter를 구현한 파생 클래스의 인스턴스)를 설치
/// - PreFilterMessage()은 응용 프로그램에서 관심을 가질 필요가 없다는 의미로 true를 반환하거나, 응용 프로금에서 처리해야 한다고 false를 반환하면 된다.
/// - PreFilterMessage()가 메개변수로 받아들이는 Message 구조체의 프로퍼티
///     - HWnd      : 메세지를 받는 윈도우의 핸들(Handel)이다. 핸들은 윈도우의 인스턴스를 식별하고 관리하기 위해 운영체제가 붙여놓은 번호이다. 
///     - Msg       : 메시지 ID
///     - LParam    : 메시지를 처리하는 데 필요한 정보다 담겨있다.
///     - WParam    : 메시지를 처리하는 데 필요한 부가 정보가 담겨있다.
///     - Result    : 메세지 처리에 대한 응답으로 윈도우 OS에 반환되는 값을 지정한다.
/// 
namespace MessageFilter
{
    class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            if(m.Msg == 0x0F || m.Msg == 0xA0 || m.Msg == 0x200 || m.Msg == 0x113)
                return false;

            Console.WriteLine($"{m.ToString()} : {m.Msg}");

            if(m.Msg == 0x201)
                Application.Exit();

            return true;
        }
    }
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            Application.AddMessageFilter(new MessageFilter());
            Application.Run(new MainApp());
        }
    }
}

