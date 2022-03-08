using static System.Console;

/**
 * ICloneable 인터페이스 
 * ICloneable 인터페이스는 Clone() 만 갖고있다.
 * .NET의 다른 유틸리티 클래스나 다른 프로그래머가 작성한 코드와
 * 호환되도록 하고 싶다면 IClonealbe을 상속하는 것이 좋다.
 */
namespace DeepCopy_2
{
    class MyClass : ICloneable
    {
        public int MyField1;
        public int MyField2;

        public object Clone()
        {
            return new MyClass() {MyField1 = this.MyField1, MyField2 = this.MyField2};
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            {
                WriteLine("Shallow Copy");
                
                MyClass source = new MyClass();
                source.MyField1 = 1;
                source.MyField2 = 2;

                MyClass target = source;
                target.MyField1 = 10;
                target.MyField2 = 20;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }

            {
                WriteLine("Deep Copy");

                MyClass source = new MyClass();
                source.MyField1 = 1;
                source.MyField2 = 2;

                MyClass target = (MyClass)source.Clone();
                target.MyField1 = 10;
                target.MyField2 = 20;

                WriteLine($"{source.MyField1} {source.MyField2}");
                WriteLine($"{target.MyField1} {target.MyField2}");
            }
        }
    }
}

