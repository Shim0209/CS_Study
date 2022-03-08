using static System.Console;

/**
 * CTS(Common Type System)에서 배열은 System.Array 클래스에 대응된다.
 * int 기반의 배열이 System.Array 형식에서 파생되었음을 보여준다.
 */
namespace MoreOnArray
{   
    class MainApp
    {
        private static bool CheckPassed(int score)
        {
            return score >= 60;
        }

        private static void ConsolePrint(int value)
        {
            Console.WriteLine($"{value} ");
        }
        static void Main(string[] args)
        {
            // 타입 알아보기
            int[] typeArray = new int[] { 1, 2, 3 };
            Console.WriteLine($"Type Of array : {typeArray.GetType()}");
            Console.WriteLine($"Base type Of array : {typeArray.GetType().BaseType}");

            // Array 클래스의 기능들

            int[] scores = new int[] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Console.WriteLine($"{score} ");
            Console.WriteLine();

            // Sort, ForEach (정적메소드 - 정렬, 모든 요소에 동일한 작업을 수행)
            Array.Sort(scores);
            Array.ForEach<int>(scores, new Action<int>(ConsolePrint));
            Console.WriteLine();

            // Rank (프로퍼티 - 배열의 차원을 반환)
            Console.WriteLine($"Number of dimensions : {scores.Rank}");

            // BinarySearch (정적메소드 - 이진탐색을 수행)
            Console.WriteLine($"Binary Search : 81 is at {Array.BinarySearch<int>(scores, 81)}");

            // IndexOf (정적메소드 - 찾고자 하는 특정 데이터의 인덱스 반환)
            Console.WriteLine($"Linear Search : 90 is at {Array.IndexOf(scores, 90)}");

            // TrueForAll (정적메소드 - 배열의 모든요소가 주어진 조건에 부합하는지의 여부를 반환)
            Console.WriteLine($"Everyone passed ? : {Array.TrueForAll<int>(scores, CheckPassed)}");

            // FindIndex (정정메소드 - 지정한 조건에 부합하는 첫 번째 요소의 인덱스 반환)
            int index = Array.FindIndex<int>(scores, (score) => score < 60);

            scores[index] = 61;
            Console.WriteLine($"Everyone passed ? : {Array.TrueForAll<int>(scores, CheckPassed)}");

            // GetLength (인스턴스 메소드 - 지정한 차원의 길이를 반환)
            Console.WriteLine($"Old length of scores : {scores.GetLength(0)}");

            // Resize (정적메소드 - 배열의 용량을 재조정)
            Array.Resize(ref scores, 10);
            Console.WriteLine($"New length of scores : {scores.Length}");

            Array.ForEach<int>(scores, new Action<int> (ConsolePrint));
            Console.WriteLine();

            // Clear (정적메소드 - 매열의 모든요소를 초기화, 배열시 숫자면 0, 논리면 false, 참조면 null)
            Array.Clear(scores, 3, 7);
            Array.ForEach<int>(scores, new Action<int>(ConsolePrint));
            Console.WriteLine();

            // Copy (정적메소드 - 배열의 일부를 다른 배열에 복사)
            int[] sliced = new int[3];
            Array.Copy(scores, 0, sliced, 0, 3); // source배열, 인덱스, target배열, 인덱스, 복사길이
            Array.ForEach<int>(sliced, new Action<int>(ConsolePrint));
            Console.WriteLine();
        }
    }
}

