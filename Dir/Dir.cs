using System;
using System.Linq;
using System.IO;

/// 파일정보과 디렉토리정보 다루기
/// - 파일과 디렉토리를 손쉽게 다루도록 .NET은 System.IO 네임스페이스 아래 다음과 같은 클래스들을 제공
///     - File          : 파일의 생성, 복사, 삭제, 이동, 조회를 처리하는 정적 메소드를 제공                          하나의 파일에 대해 한두 가지 정도의 작업을 할 때 사용
///     - FileInfo      : File 클래스와 하는 일은 동일하지만 정적 메소드 대신 인스턴스 메소드를 제공                  하나의 파일에 여러 작업을 수행할 때 사용
///     - Directory     : 디렉토리의 생성, 삭제, 이동, 조회를 처리하는 정적 메소드를 제공                             하나의 디렉토리에 한두 가지 정도의 작업을 할 때 사용
///     - DirectoryInfo : Directory 클래스와 하는 일은 동일하지만 정적 메소드 대신 인스턴스 메소드를 제공             하나의 디렉토리에 여러 작업을 수행할 때 사용
/// 
/// - 클래스 정리
/// [기능]                 [File]         [FileInfo]         [Directory]             [DirectoryInfo]
/// 생성                  Create()        Create()           CreateDirectory()       Create()
/// 복사                  Copy()          CopyTo()           -                       -
/// 삭제                  Delete()        Delete()           Delete()                Delete()
/// 이동                  Move()          MoveTo()           Move()                  MoveTo()
/// 존재여부확인           Exists()        Exists             Exists()                Exists
/// 속성조회              GetAttributes() Attributes         GetAttributes()         Attributes
/// 하위디렉토리조회       -                -                 GetDirectories()        GetDirectories()
/// 하위파일조회           -                -                 GetFiles()              GetFiles()
namespace Dir
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string directory;
            if (args.Length < 1)
                directory = "."; // 실행파일 경로 .
            else
            {
                directory = args[0];
            }

            Console.WriteLine($"{directory} diretory Info");
            Console.WriteLine($"- Directories :");
            var diretories = (from dir in Directory.GetDirectories(directory) // 하위 디렉터리 목록 조회
                              let info = new DirectoryInfo(dir) // let은 LINQ 안에서 변수를 만든다. LINQ의 var라고 생각하면 된다.
                              select new
                              {
                                  Name = info.Name,
                                  Attributes = info.Attributes
                              }).ToList();

            foreach (var d in diretories)
                Console.WriteLine($"{d.Name} : {d.Attributes}");

            Console.WriteLine("- Files :");
            var files = (from file in Directory.GetFiles(directory) // 하위 파일 목록 조회
                         let info = new FileInfo(file)
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attributes = info.Attributes
                         }).ToList();

            foreach (var f in files)
                Console.WriteLine($"{f.Name} : {f.FileSize}, {f.Attributes}");
        }
    }
}

