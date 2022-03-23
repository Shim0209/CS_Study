using static System.Console;

/// Action을 사용한 람다식
/// - Action을 사용함으로써 더 쉽게 람다식을 활용할 수 있다.
/// 
namespace ActionLambda
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;

            act2(3);
            Console.WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1, T2>({x}, {y}) : {pi}");
            };

            act3(22.0, 7.00);
        }
    }
}

