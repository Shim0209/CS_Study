using System;
using System.IO;

namespace BasicIO
{
    class MainApp
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF;
            Console.WriteLine("{0, -1} : 0x{1:X16}","Original Data",someValue);

            Stream outStream = new FileStream("a.dat", FileMode.Create);
            byte[] wByte = BitConverter.GetBytes(someValue);    // somwValue의 8바이트를 바이트 배열에 나눠 넣는다.

            Console.Write("{0,-13} : ", "Byte array");

            foreach (byte b in wByte)
                Console.Write("{0:X2} ", b);
            Console.WriteLine();

            outStream.Write(wByte, 0, wByte.Length);    // Write() 메소드를 이용해서 단번에 파일에 기록한다.
            outStream.Close();

            Stream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rbytes = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
                rbytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rbytes, 0);

            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue);
            inStream.Close();

            // 시스템마다 바이트 오더 방식이 다르다. 따라서 C# 프로그램에서 만든 파일을 다른 시스템에서 읽도록 하려면 바이트 오더의 차이를
            // 반드시 고려해야 한다. 반대로도 마찬가지이다. 네트워크를 통해 전송되는 데이터에 대해서도 같은 고려가 필요하다.
        }
    }
}

