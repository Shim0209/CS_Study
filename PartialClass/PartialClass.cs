using static System.Console;

/**
 * 분할 클래스는 여러 번에 나눠서 구현하는 클래스를 말한다.
 * 자체로는 특별한 기능이 없으며, 구현이 길어질 경우 여러 파일에 나눠서 구현할 수 있게
 * 함으로써 소스 코드 관리의 편의를 제공하는 데 의미가 있다.
 */
namespace PartialClass
{
    partial class MyClass
    {
        public void Method1()
        {
            Console.WriteLine("Method1()");
        }

        public void Method2()
        {
            Console.WriteLine("Method2()");
        }
    }

    partial class MyClass
    {
        public void Method3()
        {
            Console.WriteLine("Method3()");
        }

        public void Method4()
        {
            Console.WriteLine("Method4()");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.Method1();
            myClass.Method2();
            myClass.Method3();  
            myClass.Method4();
        }
    }
}

