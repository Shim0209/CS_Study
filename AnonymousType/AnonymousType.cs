using static System.Console;

/**
 * 무명 형식
 * - 이름이 없는 형식
 *      - 형식의 이름은 왜 필요할까? 그 이름을 이용해서 인스턴스를 만들기 때문
 * - 무명 형식은 선언과 동시에 인스턴스를 할당한다.
 * - 인스턴스를 만들고 다시는 사용하지 않을 때 무명 형식이 요긴
 * - LINQ와 함께 사용하면 아주 요긴
 * - 기본구조
 *  var myInstance = new {Name="용용이", Age=17};
 */
namespace AnonymousType
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var a = new { Name = "용용이", Age = 17 };
            Console.WriteLine($"Name:{a.Name}, Age:{a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };
            Console.Write($"Subject:{b.Subject} Scores: ");
            foreach (var score in b.Scores)
                Console.Write($"{score} ");
            Console.WriteLine();
        }
    }
}

