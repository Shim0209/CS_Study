using static System.Console;

/**
 * 오버라이딩한 메소드는 파생 클래스의 파생 클래스에서도 자동으로
 * 오버라이딩이 가능하다. 그래서 이곳에 오버라이딩을 막을 수 있는
 * 브레이크인 sealed 한정자가 필요한 것이다.
 */
namespace SealedMethod
{
    class Base
    {
        public virtual void SealMe()
        {
            WriteLine("기반 클래스 작성자가 오버라이딩을 위해서 만든 메서드로 원치 않으면 virtual만 빼주면 되기에 sealed를 사용할 필요 없음.")
        }
    }

    class Derived : Base
    {
        public sealed override void SealMe()
        {
            WriteLine("사용자가 오버라이딩해서 구현한 것으로 파생 클래스의 파생 클래스에서 다시 오버라이딩할 경우 문제의 요지가 있어 sealed 처리함.");
        }
    }

    class WantToOverride : Derived
    {
        public override void SealMe() // 오버라이딩 불가
        {
            
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            
        }
    }
}

