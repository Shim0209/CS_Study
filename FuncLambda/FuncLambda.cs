using static System.Console;

/// Func을 사용한 람다식
/// - Func을 사용함으로써 더 쉽게 람다식을 활용할 수 있다.
/// 
namespace FuncLambda
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;
            Console.WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            Console.WriteLine($"func2() : {func2(4)}");

            Func<double, double, double> func3 = (x, y) => x / y;
            Console.WriteLine($"func3(22, 7) : {func3(22, 7)}");
        }
    }
}

