using static System.Console;

/**
 * this() 생성자
 * new 연산자 없이 생성자를 호출할 수 없다.
 * this가 객체 자신을 지징하는 키워드로 this()는 자기 자신의 생성자를
 * 가리킨다. 
 * this()는 생성자에서만 사용될 수 있다.
 */
namespace ThisConstructor
{
    class MyClass
    {
        int a, b, c;

        public MyClass()
        {
            this.a = 1;
            WriteLine($"MyClass()");
        }

        public MyClass(int b) : this()
        {
            this.b = b;
            WriteLine($"MyClass({b})");
        }

        public MyClass(int b, int c) : this(b)
        {
            this.c = c;
            WriteLine($"MyClass({b}, {c})");
        }

        public void PrintField()
        {
            WriteLine($"a:{a}, b:{b}, c:{c}");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass();
            a.PrintField();
            WriteLine();

            MyClass b = new MyClass(2);
            b.PrintField();
            WriteLine();

            MyClass c = new MyClass(2, 3);
            c.PrintField();
        }
    }
}

