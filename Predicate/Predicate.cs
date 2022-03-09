using static System.Console;
/// <summary>
/// Predicate 델리게이트
/// - 주요 특징 : 리턴값이 반드시 bool이고, 파라미터는 1개
/// - .NET2.0에서 Array, List등을 지원하기 위해 만들어짐
/// - .NET3.5부터 Func이 도입되었으며 LINQ지원. Func 실제로 보다 많은 함수들을 표현할 수 있다.
/// - Predicate<T>는 Func<T, bool>과 같이 표현할 수 있다.
/// </summary>
namespace Predicate
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 무명 메서드
            Predicate<int> p = delegate (int n)
            {
                return n > 0;
            };
            bool result = p(-1);

            // 람다식 사용
            Predicate<string> p2 = s => s.StartsWith("A");
            result = p2("Apple");
        }
    }
}

