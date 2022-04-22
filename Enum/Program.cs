using System;

// Enum
// - 열거 형식의 요소가 어떤 값을 갖느냐는 별 의미가 없다.
// - 열거 형식의 각 요소는 서로 중복되지 않는 값을 갖고 있다는 데 의미가 있다.
namespace Enum
{
    class MainApp
    {
        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }
        enum DialogType { YES=10, NO, CANCEL, CONFIRM=50, OK }
        
        [Flags]
        enum MyEum
        {
            Apple = 1 << 0,
            Orange = 1 << 1,
            Kiwi = 1 << 2,
            Mango = 1 << 3
        };
        static void Main(string[] args)
        {
            Console.WriteLine((int)DialogResult.YES);
            Console.WriteLine((int)DialogResult.NO);
            Console.WriteLine((int)DialogResult.CANCEL);   
            Console.WriteLine((int)DialogResult.CONFIRM);
            Console.WriteLine((int)DialogResult.OK);

            // 열거형식 사용방법
            DialogResult result = DialogResult.YES;
            Console.WriteLine(result == DialogResult.YES);
            Console.WriteLine(result == DialogResult.NO);
            Console.WriteLine(result == DialogResult.CANCEL);
            Console.WriteLine(result == DialogResult.CONFIRM);
            Console.WriteLine(result == DialogResult.OK);

            // 열거형식의 값 증가
            Console.WriteLine((int)DialogType.YES);
            Console.WriteLine((int)DialogType.NO);
            Console.WriteLine((int)DialogType.CANCEL);
            Console.WriteLine((int)DialogType.CONFIRM);
            Console.WriteLine((int)DialogType.OK);

            // [Flags] 애트리뷰트를 갖는 열거형은 요소들의 집합으로 구성되는 값들도 표현할 수 있다.
            Console.WriteLine((MyEum)1);
            Console.WriteLine((MyEum)2);
            Console.WriteLine((MyEum)4);
            Console.WriteLine((MyEum)8);
            Console.WriteLine((MyEum)(1 | 4)); // Apple, Kiwi   (Flags 사용x -> 결과값 : 5)
            Console.WriteLine((MyEum)(1 | 8)); // Apple, Mango  (Flags 사용x -> 결과값 : 9)
        }
    }
}
