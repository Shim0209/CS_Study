using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// 손쉬운 병렬 처리를 가능케 하는 Parallel클래스
/// - Task<TResult>를 이용해 직접 구현했던 병렬 처리를 For(), Foreach() 등의 메소드를 이용해서 쉽게 구현할 수 있도록 해준다.
/// - 특정 메소드를 병렬로 호출할 때 몇 개의 스레드를 사용할지는 Parallel클래스가 내부적으로 판단하여 최적화 해준다.
/// 
namespace ParallelLoop
{
    class MainApp
    {
        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;

            if (number % 2 == 0 && number != 2)
                return false;

            for (long i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            long from = 0; //Convert.ToInt64(args[0]);
            long to = 100000; //Convert.ToInt64(args[1]);    

            Console.WriteLine($"Please press enter to start...");
            Console.ReadLine();
            Console.WriteLine($"Started...");

            DateTime startTime = DateTime.Now;
            List<long> total = new List<long>();

            Parallel.For(from, to, (long i) =>
            {
                if(IsPrime(i))
                    lock(total)
                        total.Add(i);
            });

            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime - startTime;
            Console.WriteLine($"Prime number count between {from} and {to} : {total.Count}");
            Console.WriteLine($"Elapsed time : {elapsed}");
        }
    }
}

