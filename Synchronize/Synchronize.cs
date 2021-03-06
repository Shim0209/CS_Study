using System;
using System.Threading;

/// 스레드 간의 동기화
/// - 스레드들이 순서를 갖춰 자원을 사용하게 하는 것을 동기화(Synchoronize)라고 한다.
/// - 중요! 자원을 한 번에 하나의 스레드가 사용하도록 보장 하는것
/// - .NET에는 lock키워드와 Monitor 클래스가 있다.
/// 
/// lock 키워드
/// - 사용이 쉽다
/// - lock키워드로 감싸주기만 하면 평범한 코드를 크리티컬 섹션으로 바꿀수 있다.
/// * 크리티컬 섹션 - 한 번에 한 스레드만 사용할 수 있는 코드 영역
/// - 앞 실행을 기다려야 하므로 성능이 떨어진다.
/// - 절대 사용하지 않아야할 3가지
///     1. lock(this) : this는 클래스 내부뿐만 아니라 외부에서도 자주 사용됨.
///     2. lock(typeof(SomeClass)), lock(obj.GetType()) : Type 형식의 인스턴스를
///     반환한다. 즉 코드의 어느 곳에서나 특정 형식에 대한 Type 객체를 얻을 수 있다.
///     3. string 형식 : 어떤 코드에서든 얻어낼 수 있는 string 객체는 절대로 사용해서는
///     안된다.
/// 
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
namespace Synchronize
{
    class Counter
    {
        const int LOOP_COUNT = 1000;
        readonly object thisLock;
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
                /*#region lock 사용
                lock (thisLock)
                {
                    count++;
                }
                Thread.Sleep(1);
                #endregion*/

                #region Monitor 사용
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
                #endregion
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            // lock
            while(loopCount-- > 0)
            {
                /*#region lock 사용
                lock (thisLock)
                {
                    count--;
                }
                Thread.Sleep(1);
                #endregion*/

                #region Monitor 사용
                Monitor.Enter(thisLock);
                try
                {
                    count--;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
                #endregion
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
            // 결과 : 0
        }
    }
}

