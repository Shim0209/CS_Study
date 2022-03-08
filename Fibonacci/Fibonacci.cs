using static System.Console;

namespace Fibonacci
{
    class MainApp
    {
        static int Fibonacci(int n)
        {
            if (n < 2)
                return n;
            else
                return Fibonacci(n - 1)+Fibonacci(n - 2);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                
                WriteLine("피보나치 자리수를 입력하세요. (Exit:0)");
                int n = Convert.ToInt32(ReadLine());
                if (n == 0) 
                    break;
                else
                    WriteLine($"{n}번째 피보나치 수 : {Fibonacci(n)}");
            }
        }
    }
}

