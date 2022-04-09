using System;

/// dynamic 형식
/// - dynamic 형식도 데이터 형식이다.
/// - 형식 검사를 하는 시점이 프로그램 실행 중이라는 점이 다른 형식과 다르다.
/// - C#의 강력한 형식검사의 이점과 상충되는 개념이다.
/// 
/// Duck Typing
/// - 오리처럼 걷고 오리처럼 헤엄치며 오리처럼 꽥꽥 거리는 새를 봤을 때, 나는 그 새를 오리라고 부른다. - 제임스 휘트컴 라일리
/// - 덕 타이핑은 객체지향 프로그래밍과는 상당히 다른 각도에서 형식을 바라본다. 
///     - 객체지향은 어떤 형식이 오리로 인정받으려면 그 형식의 조상 중에 오리가 있어야 한다.
///     - 덕 타이핑은 오리처럼 걷고, 오리처럼 헤엄치고, 오리처럼 꽥꽥 거리기만 하면 인정해준다. 상속은 중요하지 않다.
/// - C# 컴파일러는 상속을 받아야만 오리로 인정 해준다. 이런경우 dynamic 형식을 통해서 해결할 수 있다.
/// - dynamic 형식으로 선언하면 형식 검사를 실행할 때로 미룬다는 점을 이용하는 것이다.
namespace DuckTyping
{
    class Duck
    {
        public void Walk()
        {
            Console.WriteLine(this.GetType() + ".Walk");
        }

        public void Swim()
        {
            Console.WriteLine(this.GetType() + ".Swim");
        }

        public void Quack()
        {
            Console.WriteLine(this.GetType() + ".Quack");
        }
    }

    class Mallard : Duck
    {

    }

    class Robot
    {
        public void Walk()
        {
            Console.WriteLine(this.GetType() + ".Walk");
        }

        public void Swim()
        {
            Console.WriteLine(this.GetType() + ".Swim");
        }

        public void Quack()
        {
            Console.WriteLine(this.GetType() + ".Quack");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            dynamic[] arr = new dynamic[] {new Duck(), new Mallard(), new Robot()};

            foreach(dynamic duck in arr)
            {
                Console.WriteLine(duck.GetType());
                duck.Walk();
                duck.Swim();
                duck.Quack();

                Console.WriteLine(); 
            }
        }
    }
}

