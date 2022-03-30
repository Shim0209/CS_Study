using System;
using System.Runtime.CompilerServices;

/// 호출자 정보 애트리뷰트
/// - C# 5.0 버전부터 호출자 정보 애트리뷰트가 도입됨
/// - 호출자 정보는 메소드의 매개변수에 사용되며, 메소드의 호출자 이름, 
///     호출자 메소드가 정의된 소스 파일 경로, 심지어 소스 파일 내의 행 번호까지 알 수 있다.
/// 
/// 애트리뷰트 설명
/// - CallerMemberNameAttribute : 현재 메소드를 호출한 메소드 또는 프로퍼티의 이름을 나타낸다.
/// - CallerFilePathAttribute : 현재 메소드가 호출된 소스 파일 경로를 나타낸다. 이때 경로는 소스 코드를 컴파일할 떄의 전체 경로를 나타낸다.
/// - CallerLineNumberAttribute : 현재 메소드가 호출된 소스 파일 내의 행(Line) 번호를 나타낸다.
/// 
namespace CallerInfo
{
    public static class Trace
    {
        public static void WriteLine(string message,
            [CallerFilePath]string file = "",
            [CallerLineNumber]int line = 0,
            [CallerMemberName]string member = "")
        {
            Console.WriteLine($"{file}(Line:{line}) {member}: {message}");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("하이");
        }
    }
}

