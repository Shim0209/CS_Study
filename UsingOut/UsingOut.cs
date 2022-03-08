using static System.Console;

/*
 *  out 키워드가 ref 와 다른점
 *  ref는 안전장치가 없음. 즉, ref를 출력전용 매개변수로 받아서 값을 저장하지 않아도
 *  문제가 없음.
 *  out은 반드시 해당 메소드에서 값을 넣어줘야 한다. 또한, 호출하는 메소드에서 초기화를
 *  하지 않아도 된다. 메소드에서 값 할당을 보장받기 때문이다.
 */
namespace UsingOut
{
    class MainApp
    {
        static void Divide(int a, int b, out int c, out int d)
        {
            c = a / b;
            d = a % b;
        }
        static void Main(string[] args)
        {
            int x = 10;
            int y = 3;
          
            Divide(x, y, out int z, out int k);
            WriteLine($"a:{x}, b:{y}, {x}/{y}={z}, {x}%{y}={k}");
        }
    }
}

