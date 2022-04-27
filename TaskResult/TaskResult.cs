using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// 코드의 비동기 실행 결과를 주는 Task<TResult> 클래스
/// - Task<TResult>는 코드의 비동기 실행 결과를 손쉽게 취합할 수 있도록 도와준다.
/// - Task가 비동기로 수행할 코드를 Action대리자로 받는 대신 Func 대리자로 받는다는 점과 결과를 반환받을 수 있다는 점이 다르다.
/// - .Result 프로퍼티가 비동기 작업이 끝나야 반환하므로 .Wait()는 호출하지 않아도 되지만, 나쁜 습관을 만들 수도 있으므로 Wait()을 호출하는 것이 좋다.
/// 
namespace TaskResult
{
    class MainApp
    {
        static bool IsPrime(long number)
        {
            if (number < 2)
                return false;

            if (number % 2 == 0 && number != 2)
                return false;

            for(long i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            long from = 0; //Convert.ToInt64(args[0]);
            long to = 100000; // Convert.ToInt64(args[1]);
            int taskCount = 10; //Convert.ToInt32(args[2]); => taskCount에 따라서 처리 시간의 차이가 발생한다.

            Func<object, List<long>> FindPrimeFunc = (objRange) =>
            {
                long[] range = (long[])objRange;
                List<long> found = new List<long>();

                for(long i = range[0]; i <= range[1]; i++)
                {
                    if(IsPrime(i))
                        found.Add(i);
                }
                return found;
            };

            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];
            long currentFrom = from;
            long currentTo = to/tasks.Length;
            for(int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"Task[{i}] : {currentFrom} ~ {currentTo}");
                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] {currentFrom, currentTo});
                currentFrom = currentTo + 1;

                if (i == tasks.Length - 2)
                    currentTo = to;
                else 
                    currentTo = currentTo + (to / tasks.Length);
            }

            Console.WriteLine("Please press enter to start...");
            Console.ReadLine();
            Console.WriteLine("Started...");

            DateTime startTime = DateTime.Now;

            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();

            foreach (Task<List<long>> task in tasks)
            {
                task.Wait();
                total.AddRange(task.Result.ToArray());
            }
            DateTime endTime = DateTime.Now;

            TimeSpan elapsed = endTime - startTime;

            Console.WriteLine($"Prime number count between {from} and {to} : {total.Count}");
            Console.WriteLine($"Elapsed time : {elapsed}");
        }
    }
}

