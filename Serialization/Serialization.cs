using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// 객체 직렬화
/// - BinaryWriter/Reader와 StreamWriter/Reader는 기본 데이터 형식을 스트림에 쓰고 읽을 수 있도록 메소드들을 제공. 
/// 프로그래머가 직접 정의한 클래스나 구조체 같은 복합 데이터 형식은 지원되지 않는다.
/// - C#은 복합 데이터 형식을 쉽게 스트림에 쓰기/읽기할 수 있게 하는 직렬화(serialization)라는 메커니즘을 제공.
/// 
/// 직렬화란
/// - 객체의 상태를 메모리나 영구 저장 장치에 저장이 가능한 0과 1의 순서로 바꾸는 것을 말한다.
/// - Binary, JSON, XML의 직렬화를 지원한다.
/// - 객체 --(직렬화)--> 바이트배열 --> DBMS or MEMORY or FILE
/// 
/// 직렬화하는법
/// - [Serializable] 애트리뷰트를 클래스 선언부 앞에 붙여주면 이 클래스는 메모리나 영구 저장 장치에 저장할 수 있는 형식이 된다.
/// - BinaryFormatter는 객체를 직렬화하거나 역직렬화를 알아서 해준다.
/// - 직렬화하고 싶지 않은 필드는 [NonSerialized] 애트리뷰트를 수식해준다.
/// - 직렬화하지 못하는 필드도 [NonSerialized] 애트리뷰트를 수식해준다.
namespace Serialization
{
    [Serializable]
    class NameCard
    {
        public string Name;
        public string Phone;
        public int Age;
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            using (Stream ws = new FileStream("a.dat", FileMode.Create))
            {
                BinaryFormatter serializer = new BinaryFormatter();

                NameCard nc = new NameCard();
                nc.Name = "이진욱";
                nc.Phone = "010-0000-0000";
                nc.Age = 33;

                serializer.Serialize(ws, nc);
            }

            using Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            NameCard nc2;
            nc2 = (NameCard)deserializer.Deserialize(rs);

            Console.WriteLine($"Name : {nc2.Name}");
            Console.WriteLine($"Phone : {nc2.Phone}");
            Console.WriteLine($"Age : {nc2.Age}");
        }
    }
}

