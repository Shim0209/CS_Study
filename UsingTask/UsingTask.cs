using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// Task
/// - System.Threading.Tasks 네임스페이스에는 병행성 코드나 비동기 코드를 개발자들이 손쉽게 작성할 수 있도록 돕는 여러 가지 클래스가 있다.
/// 
/// 실행방법
/// - 프로젝트 폴더내부 .exe 파일에 위치한 상태
/// - start 프로젝트실행파일 d:\a.txt (이때 d드라이에 a.txt 파일 있어야함)
/// 
namespace UsingTask
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string srcFile = args[0];

            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state;
                File.Copy(paths[0], paths[1]);

                Console.WriteLine($"TaskID: {Task.CurrentId}, ThreadID: {Thread.CurrentThread.ManagedThreadId}, {paths[0]} was copied to {paths[1]}");
            };

            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });

            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
            });

            t1.Start();

            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });

            t3.RunSynchronously(); // RunSynchronously는 동기 실행을 위한 메소드이다.

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    }
}

