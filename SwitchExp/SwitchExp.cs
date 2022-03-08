using static System.Console;

namespace SwitchExp
{
    class MainApp
    {
        static void Main(string[] args)
        {
            WriteLine("점수를 입력하세요.");
            int score = Convert.ToInt32(Console.ReadLine());

            WriteLine("재수강인가요? (y/n)");
            string line = ReadLine();
            bool repeated = line == "y" ? true : false;

            string grade = (int)(Math.Truncate(score / 10.0) * 10) switch
            {
                90 when repeated == true => "B+",
                90 => "A",
                80 => "B",
                70 => "C",
                60 => "D",
                _ => "F"
            };

            WriteLine($"학점 : {grade}");
        }
    }
}

