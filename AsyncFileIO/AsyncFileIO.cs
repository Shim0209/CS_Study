using System;
using System.IO;
using System.Threading.Tasks;

/// .NET이 제공하는 비동기 API
/// - MS는 C# 언어가 비동기 프로그래밍 패러다임을 지원하도록 만드는 한편, .NET도 기존 API에 더불어 비동기 버전 API를
/// 새롭게 제공하도록 업그레이드했다. .NET 클래스 라이브러리 곳곳에 추가된 ~Async()라는 이름의 메소드들이다.
/// - .NET은 파일/네트워크/데이터베이스 등 다양한 분야의 클래스 라이브러리에 비동기 API를 제공한다.
/// 
/// System.IO.Stream 클래스 예시
/// 동기버전메소드           비동기버전메소드          설명
/// -------------------------------------------------------------------------
/// Read                    ReadAsync               스트림에서 데이터를 읽는다.
/// Write                   WriteAsync              스트림에 데이터를 기록한다.
/// 
/// 실행
/// - 해당 실행파일 경로에 복사할 파일이 있어야 한다.
/// - 명령어 => 실행프로그램 복사할파일이름.확장자 새로운파일이름.확장자
namespace AsyncFileIO
{
    class MainApp
    {
        // 파일 복사 후 복사한 파일 용량 반환
        static async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            using(var fromStream = new FileStream(FromPath, FileMode.Open))
            {
                long totalCopied = 0;

                using(var toStream = new FileStream(ToPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);
                        totalCopied += nRead;
                    }
                }

                return totalCopied;
            }
        }

        static async void DoCopy(string FromPath, string ToPath)
        {
            long totalCopied = await CopyAsync(FromPath, ToPath);
            Console.WriteLine($"Copied Total {totalCopied} Bytes.");
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage : AsyncFileIO <Source> <Destination>");
            }

            DoCopy(args[0], args[1]);

            Console.ReadLine();
        }
    }
}

