using static System.Console;
using MyExtension;

/**
 * 확장메소드
 * 기존 클래스의 기능을 확장하는 기법.
 * 기반 클래스를 물려받아 파생 클래스를 만든 뒤 여기에 필드나 메소드를 추가하는 상속과 다름
 * 확장 메소드는 기존 클래스의 기능을 확장한다.
 */
namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for(int i = 1; i < exponent; i++)
            {
                result = result * myInt;
            }
            return result;
        }
    }

    public static class StringExtension
    {
        public static string Append(this string myStr, string addStr)
        {
            return myStr + addStr;
        }
    }
}
namespace ExtensionMethod
{
    class MainApp
    {
        static void Main(string[] args)
        {
            WriteLine($"3^2 : {3.Square()}");
            WriteLine($"3^4 : {3.Power(4)}");
            WriteLine($"2^10 : {2.Power(10)}");
            string hello = "hello";
            WriteLine(hello.Append(", world"));
        }
    }
}

