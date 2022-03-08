using static System.Console;

/**
 * 읽기 전용 메소드
 * - 구조체에서만 생성가능
 * - 메소드에게 상태를 바꾸지 않도록 강제할때 사용
 */
namespace ReadonlyMethod
{
    class MainApp
    {
        struct ACSetting
        {
            public double currentInCelsius; // 현재온도 C
            public double target; // 희망 온도

            public readonly double GetFahrenheit() // 화씨 계산결과를 target에 저장
            {
                target = currentInCelsius * 1.8 + 32;   // 메소드에서 필드를 변경하지 못하기에 컴파일 에러 발생
                return target;
            }
        }

        static void Main(string[] args)
        {
            ACSetting acs;
            acs.currentInCelsius = 25;
            acs.target = 25;

            WriteLine($"{acs.GetFahrenheit()}");
            WriteLine($"{acs.target}");
        }
    }
}

