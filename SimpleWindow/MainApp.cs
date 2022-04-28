using System;

/// Winform 클래스 라이브러리를 이용한 윈도우 생성 절차
/// 1. System.Windows.Forms.Form 클래스에서 파생된 윈도우 폼 클래스를 선언한다.
/// 2. 1번에서 만든 클래스의 인스턴스를 System.Windows.Forms.Application.Run() 메소드에 인수로 넘겨 호출한다.
/// 
/// 실습
/// 1. 콘솔앱으로 프로젝트 생성
/// 2. .csproj 파일 수정
///     - TargetFramework를 net6.0-windows 로 수정
///     - UseWindowsForms, DisableWinExeOutputInference 추가 및 true 추가
/// 3. MainApp이 System.Windows.Forms.Form 클래스 상속 선언
/// 4. System.Windows.Forms.Application.Run()에 MainApp 인스턴스를 넘겨 호출
namespace SimpleWindow
{
    class MainApp : System.Windows.Forms.Form // MainApp이 System.Windows.Forms.Form 클래스로부터 상속받도록 선언
    {
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.Run(new MainApp()); // Application.Run() 메소드에 MainApp의 인스턴스를 인수로 넘겨 호출
        }
    }
}

