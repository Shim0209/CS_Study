using static System.Console;

/// 파일을 쓰거나 읽는 방식
/// Stram 클래스에는 Position이라는 프로퍼티가 있다. Position 프로퍼티는 현재 스트림의 읽는 위치 또는 쓰는 위치를 나타낸다.
/// - 순차 접근 : 파일을 순차적으로 쓰거나 읽는 방식
/// - 임의 접근 : 파일 내의 임의의 위치에 Position이 위치하도록 하여 쓰거나 읽는 방식 (Seek() 메소드나 Position 프로퍼티에 직접 원하는 값을 대입해 지정한 위치로 이동)
/// 
/// WriteByte()와 Seek()를 이용한 순차 접근 방식과 임의 접근 방식 예제
namespace SeqNRand
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            // 쓰기
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x01);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x02);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x03);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Seek(5, SeekOrigin.Current); // 현재 Position 위치에서 5칸 이동
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x04);
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Close();

            /// 읽기
            Stream inStream = new FileStream("a.dat", FileMode.Open);
            while(inStream.Position < inStream.Length)
                Console.WriteLine($"Position {inStream.Position + 1} : {inStream.ReadByte()}");
            
            inStream.Close();
        }
    }
}

