using static System.Console;

/**
 * 메소드 숨기기
 * new 한정자(생성자 new와 다름)로 수식함으로써 할 수 있다.
 * 오버라이딩과 다르며, 완전한 다형성을 표현하지 못함.
 */
namespace MethodHiding
{
    class Base
    {
        public void MyMethod()
        {
            WriteLine("Base.MyMethod");
        }
    }

    class Derived : Base
    {
        public new void MyMethod()
        {
            WriteLine("Derived.MyMethod");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived();
            baseOrDerived.MyMethod();
        }
    }
}

