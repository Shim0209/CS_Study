using System;

/// Value Type은 NULL값을 가질 수 없다.
/// 
/// Value Type 변수에 NULL을 갖게하려면 System.Nullable<T>나 int?을 사용한다.
namespace Nullable
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int? a = null;

            Console.WriteLine(a.HasValue);
            Console.WriteLine(a != null);

            a = 3;

            //Console.WriteLine(a.HasValue);
            //Console.WriteLine(a != null);
            //Console.WriteLine(a.Value);

            if (a.HasValue)
            {
                Console.WriteLine(a.Value);
            }
        }
    }
}
