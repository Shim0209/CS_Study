using static System.Console;

/**
 * 인터페이스의 기본 구현 메소드
 * - 인터페이스에 메소드를 추가할 때 파생 클래스에서 에러가 발생되는 걸 막기위함.
 *  즉, 기본적인 구현체를 갖도록 해서 문제를 해결.
 */
namespace DefaultImplementation
{
    interface ILogger
    {
        void WriteLog(string message);  // 기존 메소드

        void WriteError(string error)   // 새로운 메소드 추가 => 기본 구현 메소드
        {
            Console.WriteLine($"Error: {error}");
        }
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("System Up");
            logger.WriteError("System Fail");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.WriteLog("System Up");
            //clogger.WriteError("System Fail"); // 컴파일 에러 => 파생 클래스가 오버라이딩 하지 않았기 때문이다.
        }
    }
}

