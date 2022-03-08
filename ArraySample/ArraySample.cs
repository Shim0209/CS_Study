using static System.Console;

/**
 * ^ 연산자를 통해서 배열 뒤에서부터 쉽게 접근할 수 있다.
 * ^1이 배열의 가장뒤이다. 즉, 기존 'length-1'과 같다.
 */
namespace ArraySample
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5];
            scores[0] = 80;
            scores[1] = 74;
            scores[2] = 81;
            //scores[3] = 90;
            //scores[4] = 34;
            scores[^2] = 90;
            scores[^1] = 34;

            foreach (int score in scores)
                Console.WriteLine(score);

            int sum = 0;
            foreach (int score in scores)
                sum += score;

            int average = sum / scores.Length;
            Console.WriteLine($"Average Score : {average}");
        }
    }
}

