using System;

namespace IntegralTypes
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 숫자데이터 연습
            sbyte a = -10;
            byte b = 40;

            Console.WriteLine($"a={a}, b={b}");

            short c = -30000;
            ushort d = 60000;

            Console.WriteLine($"c={c}, d={d}");

            int e = -1000_0000;
            uint f = 3_0000_0000;

            Console.WriteLine($"e={e}, f={f}");

            long g = -5000_0000_0000;
            ulong h = 200_0000_0000_0000_0000;

            Console.WriteLine($"g={g}, h={h}");

            // 2, 10, 16진수 연습
            byte a2 = 240;                   // 10진수 리터럴
            Console.WriteLine($"a2={a2}");

            byte b2 = 0b1111_0000;           // 2진수 리터럴
            Console.WriteLine($"b2={b2}");

            byte c2 = 0xF0;                  // 16진수 리터럴
            Console.WriteLine($"c2={c2}");

            uint d2 = 0x1234_abcd;           // 16진수 리터럴
            Console.WriteLine($"d2={d2}");

            // Overflow
            uint e2 = uint.MaxValue;    // 1111 1111
            int e3 = int.MaxValue;      // 0111 1111

            Console.WriteLine($"e2={e2}");
            Console.WriteLine($"e3={e3}");

            e2 = e2 + 1;                // 1 0000 0000 
            e3 = e3 + 1;                // 1000 0001

            Console.WriteLine($"e2={e2}");
            Console.WriteLine($"e3={e3}");
        }
    }
}