using static System.Console;

/**
 * 메소드 오버로딩 vs 선택적 매개변수
 * 둘 모두를 함께 사용하는건 0점 짜리 코드이다.
 * 매개변수에 따라 논리가 변하면 오버로딩
 * 변하지 않으면 선택적 인수를 사용하는게 좋다.
 */
namespace OptionalParameter
{
    class MainApp
    {
        static void PrintProfile(string name, string phone = "010-0000-0000")
        {
            WriteLine($"Name: {name}, Phone: {phone}");
        }
        static void Main(string[] args)
        {
            PrintProfile(name:"심연성");
            PrintProfile(name: "심연성1", phone:"010-1111-2222");
            PrintProfile("달복이");
        }
    }
}

