using System;
using System.IO;
using FS = System.IO.FileStream; // using 별칭 지시문. System.IO.FileStream과 같이 긴 이름의 클래스를 FS라는 별칭으로 사용할 수 있도록 해준다.


/// Using 선언
/// - 컴퓨터 자원을 사용하고 해제하지 않는 실수를 줄일 수 있는 방법
/// - Using 선언은 코딩블록 마지막에 Dispose() 메소드가 호촐되도록 한다. (Stream.Close() 메소드가 IDisposable 인터페이스에 상속받은 Dispose() 메소드를 호출)
/// - 2가지 방법이 있다. (코드참고)
/// 
namespace UsingDeclaration
{
    class MainApp
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF0;
            Console.WriteLine("{0,-1} : 0x{1:X16}", "Original Data", someValue);

            // 방법1
            using(Stream outStream = new FS("a.dat", FileMode.Create))
            {
                byte[] wBytes = BitConverter.GetBytes(someValue);

                Console.Write("{0,-13} : ", "Byte array");

                foreach(byte b in wBytes)
                    Console.Write("{0:X2} ",b);
                Console.WriteLine();

                outStream.Write(wBytes, 0, wBytes.Length);
            }

            // 방법2
            using Stream inStream = new FS("a.dat", FileMode.Open);
            byte[] rBytes = new byte[8];

            int i = 0;
            while(inStream.Position < rBytes.Length)
                rBytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rBytes, 0);

            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue);
        }
    }
}

