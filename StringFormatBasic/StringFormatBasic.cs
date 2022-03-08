using System;
using System.Globalization;
using static System.Console;

namespace StringFormatBasic
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            // [Basic]
            string fmt = "{0,-20}{1,-15}{2,30}";

            WriteLine(fmt, "Publisher", "Author", "Title");
            WriteLine(fmt, "Marvel", "Stan Lee", "Iron Man");
            WriteLine(fmt, "Hanbit", "Sanghyun Park", "This is C#");
            WriteLine(fmt, "Prentice Hall", "K&R", "The C Programming Language");

            // [Number]
            // D : 10진수
            WriteLine("10진수 : {0:D}", 123);
            WriteLine("10진수 : {0:D5}", 123);

            // X : 16진수
            WriteLine("16진수 : 0x{0:X}", 0xFF1234);
            WriteLine("16진수 : 0x{0:X8}", 0xFF1234);

            // N : 숫자
            WriteLine("숫자 : {0:N}", 123456789);
            WriteLine("숫자 : {0:N0}", 123456789);    // 자릿수 0은 소수점 이하를 제거함

            // F : 고정소수점
            WriteLine("고정소수점 : {0:F}", 123.45);
            WriteLine("고정소수점 : {0:F5}", 123.45);

            // E : 공학용
            WriteLine("공학 : {0:E}", 123.456789);

            // Datetime
            DateTime dt = new DateTime(2022, 02, 01, 16, 35, 30);
            WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh-mm-ss (ddd)}", dt);
            WriteLine("24시간 형식: {0:yyyy-MM-dd HH-mm-ss (dddd)}", dt);

            CultureInfo ciKo = new CultureInfo("ko-KR");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciKo));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciKo));
            WriteLine(ciKo);

            CultureInfo ciEn = new CultureInfo("en-US");
            WriteLine();
            WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciEn));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciEn));
            WriteLine(ciEn);
        }
    }
}

