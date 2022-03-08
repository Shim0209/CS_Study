using System;
using System.IO;

/**
 * 인터페이스
 * - 메소드, 이벤트, 인덱서, 프로퍼티만 가질 수 있다.
 * - 구현부가 없다.
 * - 한정자를 사용할 수 없으며, 모두 public으로 선언된다.
 * - 인스턴스를 만들 수 없다.
 * - c#에서는 인터페이스 앞에 'I'를 붙이는게 관습이다.
 */
namespace Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}",DateTime.Now.ToLongTimeString(), message);
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), message);
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while (true)
            {
                Console.Write("온도를 입력하세요 : ");
                string temperature = Console.ReadLine();
                if (temperature == "")
                    break;

                logger.WriteLog("현재 온도 : " + temperature);
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            /*ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
            monitor.start();*/

            ClimateMonitor conMonitor = new ClimateMonitor(new ConsoleLogger());
            conMonitor.start();
        }
    }
}

