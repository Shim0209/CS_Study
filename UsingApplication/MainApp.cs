using System;
using System.Windows.Forms; 

/// Application 클래스
/// - Application 클래스는 크게 두 가지 역할을 수행한다.
///     1. 윈도우 응용 프로그램을 시작하고 종료시키는 메소드를 제공
///         - Application.Run()
///         - Application.Exit()
///     2. 윈도우 메세지를 처리하는 것
/// 
/// - Exit() 메소드가 호출된다고 해서 응용 프로그램이 바로 종료되는 것은 아니다. 응용 프로그램이 갖고 있느 모든 윈도우를 닫은 뒤 Run() 메소드가 반환되도록 하는것이다.
/// 따라서 Run() 메소드 뒤에 자원을 정리하는 코드를 넣어두면 우아하게 응용 프로그램을 종료시킬 수 있다.
namespace UsingApplication
{
    class MainApp : Form
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp();

            form.Click += new EventHandler((sender, eventArgs) =>
            {
                Console.WriteLine("Closing Window...");
                Application.Exit();
            });

            Console.WriteLine("Starting Window Application...");
            Application.Run(form);

            Console.WriteLine("Exiting Window Application...");
        }
    }
}

