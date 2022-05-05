using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class MainApp
    {
        static void Main(string[] args)
        {
            /*if(args.Length < 4)
            {
                Console.WriteLine($"사용법 : {Process.GetCurrentProcess().ProcessName} <Bind IP> <Bind Port> <Server IP> <Message>");
                return;
            }*/

            string bindIP = "127.0.0.1"; // args[0];
            int bindPort = 10000; // Convert.ToInt32(args[1]);
            string serverIP = "127.0.0.1"; // args[2];
            const int serverPort = 5425;
            string message = "안녕하세요"; // args[3];

            try
            {
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIP), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
                Console.WriteLine($"클라이언트: {clientAddress.ToString()}, 서버 {serverAddress.ToString()}");

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress); // 서버가 수신 대기하고 있는 IP 주소와 포트 번호를 향해 연결 요청을 수행한다.

                byte[] data = Encoding.Default.GetBytes(message);

                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"송신: {message}");

                data = new byte[256];
                string responseData = "";
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.Default.GetString(data, 0, bytes);
                Console.WriteLine($"수신: {responseData}");

                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("클라이언트를 종료합니다.");
        }
    }
}

