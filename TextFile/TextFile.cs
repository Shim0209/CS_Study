using static System.Console;

/// 텍스트 파일 처리를 위한 StreamWriter/StreamReader
/// - .NET은 텍스트 파일을 쓰고 읽을 수 있도록 StreamWriter/StreamReader를 제공한다.
/// - 텍스트 파일은 구조는 간단하지만 활용도가 높다.
/// 
namespace TextFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("a.dat", FileMode.Create)))
            {
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("Good morning");
                sw.WriteLine(uint.MaxValue);
                sw.WriteLine("안녕하세요!");
                sw.WriteLine(double.MaxValue);
            }

            using (StreamReader sr = new StreamReader(new FileStream("a.dat", FileMode.Open)))
            {
                Console.WriteLine($"File size : {sr.BaseStream.Length} bytes");

                while(sr.EndOfStream == false)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
}

