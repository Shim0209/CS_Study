using System;
using static System.Console;

namespace RectArea
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            WriteLine("사각형의 너비를 입력하세요.");
            string with = ReadLine();

            WriteLine("사각형의 높이를 입력하세요.");
            string height = ReadLine();

            int rectArea = int.Parse(with) * int.Parse(height);
            WriteLine($"사격형의 넓이는 : {rectArea}");
        }
    }
}

