using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// 컬렉션의 직렬화 지원
namespace SerializingCollection
{
    [Serializable]
    class NameCard
    {
        public NameCard(string name, string phone, int age)
        {
            this.Name = name;
            this.Phone = phone; 
            this.Age = age; 
        }

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

                List<NameCard> list = new List<NameCard>();
                list.Add(new NameCard("나연", "010-0000-0000", 25));
                list.Add(new NameCard("사나", "010-0001-0001", 23));
                list.Add(new NameCard("미나", "010-0002-0002", 21));

                serializer.Serialize(ws, list);
            }

            using Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            List<NameCard> list2;
            list2 = (List<NameCard>)deserializer.Deserialize(rs);

            foreach(NameCard card in list2)
            {
                Console.WriteLine($"Name: {card.Name}, Phone: {card.Phone}, Age: {card.Age}");
            }
        }
    }
}

