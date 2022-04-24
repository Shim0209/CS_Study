using System;
using System.Threading;

/// Monitor 클래스로 동기화하기
/// - Monitor 클래스는 스레드 동기화에 사용하는 몇 가지 정적 메소드를 제공한다.
/// - Monitor.Enter() 메소드는 크리티컬 섹션을 만든다.
/// - Monitor.Exit() 메소드는 크리티컬 섹션을 제거한다.
/// - Monitor 클래스를 사용한다는건 Monitor.Wait()과 Monitor.Pulse() 때문일 것이다.
/// - Monitor.Wait() 메소드는 스레드를 WaitSleepJoin 상태로 만든다. 스레드는 동기화를 위해
/// 갖고 있던 lock을 내려놓은 뒤 Waiting Queue라고 하는 큐에 입력되고, 다른 스레드가 lock을
/// 얻어 작업을 수행한다.
/// - Monitor.Pulse() 메소드를 호출하면 CLR은 Waiting Queue에서 첫 번째 위치에 있는 스레드를
/// 꺼낸 뒤 Ready Queue에 입력한다. 입력된 차례에 따라 락을 얻어 Running 상태에 들어간다.
/// * Thread.Sleep() 메소드도 스레드를 WaitSleepJoin 상태로 만들지만 깨울수는 없다.
/// 
/// 코드설명
/// - 크리티컬 섹션 영역을 사용하지 않고 Pulse(), Sleep()을 통해 같은 메소드가 반복되는걸
/// 막고 동작시킨다.
namespace WaitPulse
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;
        // lockedConnt와 count는 스레드가 블록될 조건을 검사하기 위해 사용됨
        // lockedCount는 count 변수를 다른 스레드가 사용하고 있는지를 판별하기 위함
        // count는 각 스레드가 너무 오랫동안 count 변수를 독차지하는걸 막기위함
        bool lockedCount = false;
        private int count;
        public int Count
        {
            get { return count; }
        }
        public Counter()
        {
            thisLock = new object();
            count = 0;
        }
        public void Increase()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    // count가 0보다 크거나
                    // lockedCount가 다른 스레드에 의해 true로 바뀌어있으면 현재
                    // 스레드를 블록시킨다.
                    while (count > 0 || lockedCount == true)
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count++;
                    // lockedCount를 false로 만든뒤에 다른 스레드를 깨운다.
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;

            while(loopCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true)
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count--;
                    lockedCount = false;

                    Monitor.Pulse(thisLock);
                }
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }
    }
}

