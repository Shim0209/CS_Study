using System;

/// 이벤트 사용법
/// 1. 대리자를 선언 (클래스 선언 내부/외부 모두 가능)
/// 2. 클래스 내에 1에서 선언한 대리자의 인스턴스를 event 한정자로 수식해서 선언
/// 3. 이벤트 핸들러 작성. (조건 : 1에서 선언한 대리자와 일치하는 메소드)
/// 4. 클래스의 인스턴스를 생성하고 이 객체의 이벤트에 3에서 작성한 이벤트 핸들러를 등록
/// 5. 이벤트가 발생하면 이벤트 핸들러가 호출
/// 
/// 대리자와 이벤트
/// - 이벤트는 외부에서 직접 사용할 수 없다. public 한정자로 선언되어 있어도 자신이 선언된 클래스 외부에서는 호출이 불가능
/// - 대리자는 public이나 internal로 수식되어 있으면 클래스 외부에서라도 얼마든지 호출이 가능.
/// 대리자와 달리 이벤트가 호출될 수 없다는 사실은 견고한 이벤트 기반 프로그래밍에 대한 기대를 가능하게 한다.
///     
/// 
namespace EventTest
{
    // 1. 대리자 선언
    delegate void EventHandler(string message);

    class MyNotifier
    {
        // 2. 대리자 인스턴스를 event 한정자로 수식해서 선언
        public event EventHandler SomethingHappened;  
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if(temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(String.Format("{0} : 짝", number));
            }
        }
    }
    class MainApp
    {
        // 3. 이벤트 핸들러 작성
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            // 4. 클래스 인스턴스 생성 및 이벤트 등록
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            // 5. 이벤트가 발생시 핸들러 호출
            for(int i = 1; i<30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}

