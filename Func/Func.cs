using static System.Console;
/// <summary>
/// Func 델리게이트
/// - 주요 특징 : 반드시 리턴 타입이 존재 한다.
/// - 파라미터는 0 ~16개까지 가능하다
///     - 0개 : Func<T> delegate => 이경우 T는 리턴값의 타입을 가리킨다.
///     - 1개 : Func<T, TResult> delegate
///     - 2개 : Func<T1, T2, TResult> delegate
/// </summary>
namespace Func
{
    static class MainApp
    {
        static void Main(string[] args)
        {
            // 메서드 지정
            System.Func<bool> f = IsValid;
            bool result = f();

            System.Func<int, bool> c = IsValidRange;
            bool result2 = c(10);

            // 무명 메서드 지정
            Func<int> fa = delegate
            {
                return _state == 0;
            };
            result = fa();

            Func<int, bool> c2 = delegate (int n)
            {
                return n > 0;
            };
            result2 = c2(-1);

            // 람다식 이용
            Func<int> fb = () => _state == 0;
            result = fb();

            Func<int, bool> c3 = n => n > 0;
            result2 = c3(-2);
        }

        private static bool IsValid()
        {
            return _state == 0;
        }

        private static bool IsValidRange(int n)
        {
            return n > 0;
        }
    }
}

