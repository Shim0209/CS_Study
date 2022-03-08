using static System.Console;

/**
 * 형식 변환을 위한 연산자
 * is : 객체가 해당 형식에 해당하는지 검사하여 그 결과를 bool 값으로 반환
 * as : 형식 변환 연산자와 같은 역할을 한다. 다만 형식 변환 연산자가 반환에
 *      실패하는 경우 예외를 던지는 반면에 as 연산자는 객체 참조를 null로
 *      만든다는 것이 다르다.
 *      단, as 연산자는 참조 형식에 대해서만 사용이 가능하다.
 */
namespace TypeCasting
{
    class Mammal
    {
        public void Nurse()
        {
            WriteLine("Nurse()");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            WriteLine("Bark()");
        }
    }

    class Cat : Mammal
    {
        public void Meow()
        {
            WriteLine("Meow()");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            // is
            Mammal mammal = new Dog();
            Dog dog;

            if (mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            // as
            Mammal mammal2 = new Cat();
            Cat cat = mammal2 as Cat;
            if(cat != null)
            {
                cat.Meow();
            }

            // 자식클래스끼리의 형변환
            Cat cat2 = mammal as Cat; // mammal == dog
            if (cat2 != null)
            {
                cat2.Meow();
            }
            else
            {
                WriteLine("cat2 is not a cat");
            }
        }
    }
}

