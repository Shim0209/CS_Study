using static System.Console;

namespace SwapByValueRef
{
    class MainApp
    {
        static void SwapByValue(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SwapByRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int x = 3; 
            int y = 4;

            SwapByValue(x, y);
            WriteLine($"SwapByValue => x: {x}, y: {y}");

            SwapByRef(ref x, ref y);
            WriteLine($"SwapByRef => x: {x}, y: {y}");
        }
    }
}

