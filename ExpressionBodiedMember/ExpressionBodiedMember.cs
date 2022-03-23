using System;
using System.Collections.Generic;

/// 식 본문 멤버 (Expression-Bodied Member)
/// - 메소드를 비롯하여 속성(인덱서), 생성자, 종료자는 클래스의 멤버로서 본문이 중괄호 {}로 만들어져 있다.
/// 
namespace ExpressionBodiedMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        // 메서드
        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var s in list)
                Console.WriteLine(s);
        }
        // 생성자
        public FriendList() => Console.WriteLine("FriendList()");
        // 종료자
        ~FriendList() => Console.WriteLine("~FriendList()");
        
        // public int Capacity => list.Capacity; // 읽기 전용
        // 속성
        public int Capacity 
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        //public string this[int index] => list[index]; // 읽기 전용
        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("Mina");
            obj.Add("Sana");
            obj.Add("Momo");
            obj.Remove("Momo");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine($"{obj.Capacity}");

            Console.WriteLine($"{obj[0]}");
            obj[0] = "Nayeon";
            obj.PrintAll();
        }
    }
}

