/// <summary>
/// Action 델리게이트
/// - 중요 특징 : 리턴 값이 없어야 한다.
/// - 파라미터는 0 ~ 16개까지 가능하다
///     - 0개 : Action delegate
///     - 1개 : Action<T> delegate
///     - 2개 : Action<T, T> delegate
/// - 기타 : 많은 함수의 경우 대개 3~5개의 파라미터가 있다.
/// 
/// </summary>
namespace Action
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // Action<T>
            // 입력 : T 타입
            // 리턴값 : 없음

            // 기존 메서드 지정
            System.Action<String> act = Output;
            act("Hello");

            // 무명 메서드 지정
            Action<string, string> act2 = delegate (string msg, string title)
            {
                Console.WriteLine($"{title} - {msg}");
            };
            act2("No data found", "Error");

            // 람다식 사용
            Action<int> act3 = code => Console.WriteLine($"Code : {code}");
            act3(1004);
        }

        static void Output(string s)
        {
            Console.WriteLine(s);
        }
    }
}

