using System;
using System.Threading.Tasks;

/// async 한정자와 await 연산자로 만드는 비동기 코드
/// - async 한정자는 메소드, 이벤트 처리기, 태스크, 람다식 등을 수식함으로써 c# 컴파일러가 이돌을 호출하는 코드를 만날 때 
/// 호출 결과를 기다리지않고 바로 다음 코드로 이동하도록 실행 코드를 생성하게 한다.
/// - async로 한정하는 메소드는 반환 형식이 Task, Task<TResult>, void 여야 한다는 제약이 있다.
///     - 실행하고 잊어버릴 작업을 담고 있는 메소드는 반환 형식으 void
///     - 작업이 완료될때까지 기다려야 하는 메소드라면 Task, Task<TResult> 
/// 
/// 동작 설명
/// - C# 컴파일러는 Task, Task<TResult>형식의 메소드를 async 한정자가 수식하는경우
/// 1. await 연산자가 해당 메소드 내부의 어디에 위치하는지 찾는다.
/// 2. await 연산자를 찾으면 그곳에서 호출자에게 제어를 돌려주도록 실행 파일을 만든다. (못찾으면 해당 메소드/태스크는 동기적으로 실행)
/// 
namespace Async
{
    class MainApp
    {
        // 2번 동작
        async static private void MyMethodAsync(int count)
        {
            Console.WriteLine("C");
            Console.WriteLine("D");

            // 3번 동작
            await Task.Run(async () =>
            {
                // 5번 동작 (비동기)
                for(int i = 1; i <= count; i++)
                {
                    Console.WriteLine($"{i}/{count} ...");
                    await Task.Delay(100); // Task.Delay()는 Thread.Sleep()의 비동기 버전이다.
                }
            });

            Console.WriteLine("G");
            Console.WriteLine("H");
        }

        static void Caller()
        {
            Console.WriteLine("A");
            Console.WriteLine("B");

            MyMethodAsync(3);

            Console.WriteLine("E");
            Console.WriteLine("F");
        }
        static void Main(string[] args)
        {
            // 1번 동작
            Caller(); // 4번 동작 (제어를 돌려줌)
            // 5번 동작 (비동기)

            Console.ReadLine(); // 프로그램 종료 방지
        }
    }
}

