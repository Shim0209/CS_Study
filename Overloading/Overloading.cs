using static System.Console;

namespace Overloading
{
    class MainApp
    {
        static int Plus(int a, int b)
        {
            WriteLine("Plus(int, int)");
            return a + b;
        }

        static int Plus(int a, int b, int c)
        {
            WriteLine("Plus(int, int, int)");
            return a + b + c;
        }

        static double Plus(double a, double b)
        {
            WriteLine("Plus(double, double)");
            return a + b;
        }

        static double Plus(int a, double b)
        {
            WriteLine("Plus(int, double)");
            return a + b;
        }

        static void Main(string[] args)
        {
            WriteLine(Plus(1, 2));
            WriteLine(Plus(1, 2, 3));
            WriteLine(Plus(1.2, 2.3));
            WriteLine(Plus(1, 2.3));
        }
    }
}

