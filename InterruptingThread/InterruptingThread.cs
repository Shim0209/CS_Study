using System;
using System.Security.Permissions;
using System.Threading;

/// 스레드 인터럽트
/// - Thread.Interrupt() 메소드는 스레드가 한참 동작 중인 상태를 피해서
/// WaitJoinSleep 상태에 들어갔을 때 ThreadInterruptedException 예외를
/// 던져 스레드를 중지시킨다. (좀더 신사적이다)
/// - 인터럽트는 WaitSleepJoin 상태에 있을 때는 즉시 중단시키지만, 다른 상태일
/// 때는 스레드를 지켜보고 있다가 WaitSleepJoin 상태가 되면 그제서야 스레드를 
/// 중단시킨다. 이런 특징때문에 프로그래머는 최소한 코드가 '절대로 중단되면 안 되는'
/// 작업을 하고 있을 때는 중단되지 않는다는 보장을 받을 수 있다.
namespace InterruptingThread
{
    class SideTask
    {
        int count;

        public SideTask(int count)
        {
            this.count = count;
        }
        public void KeepAlive()
        {
            try
            {
                Console.WriteLine("Running thread isn't gonna be interrupted");
                Thread.SpinWait(10000000); 
                // 스레드를 대기하게 하지만, Running 상태를 유지
                // 파라미터값이 작으면 스레드가 여러번 재 시작됨.

                while(count > 0)
                {
                    Console.WriteLine($"{count--} left");

                    Console.WriteLine("Entering into WaitJoinSleep State...");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            Console.WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("Interrupting thread...");
            t1.Interrupt();

            Console.WriteLine("Waitung until thread stops...");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}

