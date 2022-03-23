using System;

/// 식 형식의 람다식
/// - 람다식은 익명 메소드를 만들기 위해 사용한다.
/// - 람다식으로 만드는 익명 메소드는 무명 함수라고 부른다.
/// - 반환 형식이 있어야 한다.
/// 
namespace SimpleLambda
{
    class MainApp
    {
        // 익명 메소드를 만들려면 대리자가 필요하다.
        delegate int Calculate(int a, int b);
        static void Main(string[] args)
        {
            // 익명 메소드를 람다식으로 만들었다.
            Calculate calc = (a, b) => a + b;

            // C# 컴파일러는 Calculate 대리자의 선언 코드로부터 이 람다식이 만드는 익명 메소드의 매개변수의 형식을 유추해낸다.
            Console.WriteLine($"{3} + {4} : {calc(3,4)}");
        }
    }
}

