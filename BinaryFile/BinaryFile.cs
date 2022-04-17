using System;
using System.IO;

/// 이진 데이터 처리를 위한 BinaryWriter/BinaryReader
/// - FileStream 클래스는 데이터를 저장할 떄 반드시 byte 형식 또는 byte 배열 형식으로 변환해야 한다는 문제가 있다. (읽을 때도 마찬가지)
/// - BinaryWriter는 스트림에 이진 데이터를 기록하기 위한 목적
/// - BinaryReader는 스트림으로부터 이진 데이터를 읽어 들이기 위한 목적
/// 
namespace BinaryFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {
                bw.Write(int.MaxValue);
                bw.Write("Good morning");
                bw.Write(uint.MaxValue);
                bw.Write("안녕하세요!");
                bw.Write(double.MaxValue);
            }

            using BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));

            Console.WriteLine($"File size : {br.BaseStream.Length} bytes");
            Console.WriteLine($"{br.ReadInt32()}");
            Console.WriteLine($"{br.ReadString()}");
            Console.WriteLine($"{br.ReadUInt32()}");
            Console.WriteLine($"{br.ReadString()}");   
            Console.WriteLine($"{br.ReadDouble()}");    
        }
    }
}

