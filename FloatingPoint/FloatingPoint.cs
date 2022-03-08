using System;

namespace FloatingPoint
{
    class MainApp
    {
        static void Main(string[] args)
        {
            float a = 3.1415_9265_3589_7932_3846_2643_3832_79f;
            Console.WriteLine(a);   // 3.1415927

            double b = 3.1415_9265_3589_7932_3846_2643_3832_79;
            Console.WriteLine(b);   // 3.1415927410125732

            decimal c = 3.1415_9265_3589_7932_3846_2643_3832_79m;
            Console.WriteLine(c);   // 3.1415926535897932384626433833
        }
    }
}