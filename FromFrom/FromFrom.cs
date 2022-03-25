using System;
using System.Linq;

/// 여러 개의 데이터 원본에 질의하기
/// - from 문을 중첩해서 사용하면 된다 (foreach문을 중첩해서 사용하는 것처럼)
/// 
namespace FromFrom
{
    class Class
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Class[] arrClass =
            {
                new Class() { Name = "연두반", Score = new int[] { 99, 80, 70, 25 } },
                new Class() { Name = "분홍반", Score = new int[] { 60, 45, 87, 72 } },
                new Class() { Name = "노랑반", Score = new int[] { 92, 30, 85, 94 } },
                new Class() { Name = "파랑반", Score = new int[] { 100, 54, 78, 70 } },
                new Class() { Name = "보라반", Score = new int[] { 70, 70, 95, 87 } }
            };

            var classes = from c in arrClass
                          from s in c.Score
                          where s < 60
                          orderby s
                          select new { c.Name, Lowest = s };

            foreach (var c in classes)
                Console.WriteLine($"낙제 : {c.Name} ({c.Lowest}))");
        }
    }
}

