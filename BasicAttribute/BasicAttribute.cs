using static System.Console;

/// 애트리뷰트
/// - 애트리뷰트는 코드에 대한 부가 정보를 기록하고 읽을 수 있는 기능이다.
/// - 주석은 사람이 읽고 쓰는 정보, 애트리뷰트는 사람이 작성하고 컴퓨터가 읽는 정보
/// - C# 컴파일러나 C#으로 작성된 프로그램이 이 정보를 읽고 사용할 수 있다.
/// - 애트리뷰트나 리플렉션을 통해 얻는 정보들도 메타데이터(데이터의 데이터)라고 할 수 있다.
/// 
/// 예제 설명
/// - 기존에 사용하던 OldMethod()를 폐기시키고 NewMethod()를 사용하도록 해당 클래스를 
/// 사용하는 프로그래머에게 알리기 위해 애트리뷰트를 활용
namespace BasicAttribute
{
    class MyClass
    {
        [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 이용하세요.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm old");
        }

        public void NewMethod()
        {
            Console.WriteLine("I'm new");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.OldMethod();
            obj.NewMethod();
        }
    }
}

