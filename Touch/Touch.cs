using System;
using System.IO;

/// 디렉토리/파일 생성하기
/// - 예제
/// 인수로 입력받은 경로에 새 디렉토리나 파일을 만든다.
/// 만약 사용자가 입력한 경로에 이미 만들어져 있는 파일이나 디렉토리가 존재한다면 해당 파일이나 디렉토리의 최종 수정 시간만 갱신한다.
/// 
/// - 실행방법
/// 1. cmd창에서 해당 'Touch.exe'파일로 접근
/// 2. 'Touch.exe Path File/Directory' 입력
/// 
namespace Touch
{
    class MainApp
    {
        static void OnWrongPathType(string type)
        {
            Console.WriteLine($"{type} is wrong type");
            return;
        }
        static void Main(string[] args) // 0번 path, 1번 file/directory
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                return;
            }

            string path = args[0];
            string type = "File";
            if(args.Length > 1)
                type = args[1];

            if(File.Exists(path) || Directory.Exists(path))
            {
                if (type == "File")
                    File.SetLastWriteTime(path, DateTime.Now);
                else if (type == "Directory")
                    Directory.SetLastWriteTime(path, DateTime.Now);
                else
                {
                    OnWrongPathType(path);
                    return;
                }
                Console.WriteLine($"Updated {path} {type}");
            }
            else
            {
                if (type == "File")
                    File.Create(path).Close();
                else if (type == "Directory")
                    Directory.CreateDirectory(path);
                else
                {
                    OnWrongPathType(path);
                    return;
                }
                Console.WriteLine($"Created {path} {type}");
            }
        }
    }
}

