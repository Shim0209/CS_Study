using System;

/// Boxing
/// - Value Type의 값을 캐스팅을 통해 Reference Type으로 변경할 경우, Reference Type의 객체는 새 객체를 Managed Heap에 만들고, 스택의 값을 Heap에 복사하는데, 이를 Boxing이라 한다.
/// 
/// Unboxing
/// - 반대로 Boxing된 값을 Heap에서 Stack으로 Value Type으로 복원하는 과정은 Unboxing이라고 한다.
/// 
/// Boxing/Unboxing을 대량의 데이터 구조에서 자주 발생시키면, 성능을 크게 저하시키는 요인이 된다.
namespace BoxingUnboxing
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int a = 123;
            object b = (object)a;   // a에 담긴 값을 박싱해서 힙에 저장
            int c = (int)b;         // b에 담긴 값을 언박싱해서 스택에 저장

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            double x = 3.1415213;
            object y = (object)x;   // x에 담긴 값을 박싱해서 힙에 저장
            double z = (double)y;   // y에 담긴 값을 언박싱해서 스택에 저장

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }
    }
}
