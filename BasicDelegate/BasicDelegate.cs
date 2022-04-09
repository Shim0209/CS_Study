using static System.Console;

/// 델리게이트 기초적인 사용법 학습
/// 퀴즈 1
/// - 리턴 타입은 unsigned 16비트 정수
/// - 델리게이트명은 MyDelegate
/// - 2개의 파라미터, 첫번째는 문자열 배열, 두번째는 IComparable 인터페이스
/// 
/// 퀴즈 2
/// - 위의 델리게이트를 사용하는 예제 작성
namespace BasicDelegate
{
    // 두번째 매개변수용
    class MyComp : IComparable
    {
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }
    class MainApp
    {
        // 퀴즈 1
        public delegate ushort MyDelegate(string[] s, IComparable c);
        
        static void Main(string[] args)
        {
            ushort MyFunc(string[] s, IComparable c)
            {
                return 0;
            }
            // 퀴즈 2
            MyDelegate myDel = new MyDelegate(MyFunc);

            string[] s = new string[10];
            IComparable c = new MyComp();
            myDel(s, c);
        }
    }
}

