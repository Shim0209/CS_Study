using System;
using static System.Console;

/**
 * 튜플
 * - 여러 필드를 담을 수 있는 구조체이다.
 * - 튜플은 형식 이름이 없다.
 * - 프로그램 전체에서 사용할 형식을 선언할 때가 아닌, 즉석에서 사용할 복합 데이터 형식을 선언할 때 적합.
 * - 구조체이므로 값 형식이다. ( 생성된 지역에서 벗어나면 스택에서 소멸 -> 프로그램에 장기적인 부담을 주지 않는다는 장점 )
 * 
 * 명명되지 않는 튜플
 * - 괄호 사이에 두개 이상의 필드를 지정함으로써 생성
 * - Item1, Item2, ... 순으로 자동지정 (이유는 System.ValueTuple 구조체를 기반으로 만들어졌기 때문)
 * 
 * 명명된 튜플
 * - 필드의 이름을 지정할 수 있는 명명된 튜플
 * 
 * 튜플 분해
 * - var(변수, 변수) = tuple;
 * - var(변수, _) = tuple; (2번째 필드 무시)
 * - var(변수, 변수, ..) = {값, 값, ..}; 즉석해서 튜플을 만들어서 분해
 */
namespace Tuple
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 명명되지 않은 튜플
            var a = ("슈퍼맨", 9999);
            WriteLine($"{a.Item1}, {a.Item2}");

            // 명명된 튜플
            var b = (Name: "조커", Age: 8888);
            WriteLine($"{b.Name}, {b.Age}");

            // 분해
            var (name, age) = b;
            WriteLine($"{name}, {age}");

            // 분해2
            var (name2, age2) = ("얌미", 7777);
            WriteLine($"{name2}, {age2}");

            // 명명된 튜플 = 명명되지 않은 튜플
            b = a;
            WriteLine($"{b.Name}, {b.Age}");
        }
    }
}

