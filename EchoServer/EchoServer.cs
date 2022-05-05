using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

/// TcpListener와 TcpClient
/// - .NET의 클래스인 TcpListener와 TcpClient는 TCP/IP 서버/클라이언트 동작 과정을 추상화한 것이다.
/// 
/// TcpListener는 서버 애플리케이션에서 사용되며, 클라이언트의 연결 요청을 기다리는 역할을 한다.
/// TcpClient는 서버 애플리케이션과 클라이언트 애플리케이션 양쪽에서 사용된다.
///     - 클라이언트에서는 서버에 연결 요청을 하는 역할
///     - 서버에서는 클라이언트와의 통신에 사용할 수 있는 TcpClient의 인스턴스를 얻는 역할
///     - GetStream() 메소드가 반환하는 NetworkStream 객체롤 통해 데이터를 주고받을 수 있다.
///         - NetworkStream.Write()로 데이터를 보낸다.
///         - NetworkStream.Read()로 데이터를 읽는다.
///     - 서버와 클라이언트의 연결을 종료할 때는 NetworkStream 객체와 TcpClient 객체 모두 Close() 메소드를 호출해야 한다.
///     
/// IPEndPoint는 IP 통신에 필요한 IP 주소와 출입구(포트)를 나타낸다.
/// 
/// 127.0.0.1은 컴퓨터의 네트워크 입출력 기능을 시험하기 위해 가상으로 할당한 주소이다. 이 주소를 사용하면 네트워크 출력에 데이터를 기록시 네트워크 바깥으로
/// 나가지 않고 (링크 계층을 거치지 않음) 다시 자기 자신에게로 패킷을 보내게 된다. 따라서 루프백 주소라고 부르기도 한다.
namespace EchoServer
{
    class MainApp
    {
        static void Main(string[] args)
        {
            /*if(args.Length < 1)
            {
                Console.WriteLine($"사용법 : {Process.GetCurrentProcess().ProcessName} <Bind IP>");
                return;
            }*/

            string bindIP = "127.0.0.1"; //args[0];
            const int bindPort = 5425;
            TcpListener server = null;

            try
            {
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIP), bindPort); // Port를 0으로 설정하면 OS에서 임의의 번호로 할당
                server = new TcpListener(localAddress);
                server.Start(); // 서버시작 -> 클라이언트가 TcpClient.Connect()를 호출하여 연결 요청해오기를 기다리기 시작한다.
                Console.WriteLine("메아리 서버 시작... ");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient(); // 호출하면 코드는 블록되어 메소드가 반환할 때까지 진행하지 않는다. 클라이언트 요청이 오면 반환된다.
                    Console.WriteLine($"클라이언트 접속 : {((IPEndPoint)client.Client.RemoteEndPoint).ToString()}");

                    NetworkStream stream = client.GetStream(); // TcpClient를 통해 NetworkStream 객체를 얻는다.

                    int length;
                    string data = null;
                    byte[] bytes = new byte[256];

                    while((length = stream.Read(bytes, 0, bytes.Length)) != 0) // 보내온 데이터를 읽어들인다. 연결이 끊어지면 0을 반환한다.
                    {
                        data = Encoding.Default.GetString(bytes, 0, length);
                        Console.WriteLine(String.Format("수신: {0}", data));

                        byte[] msg = Encoding.Default.GetBytes(data);

                        stream.Write(msg, 0, msg.Length); // 메세지를 전송한다.
                        Console.WriteLine(String.Format("송신: {0}", data));
                    }

                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("서버를 종료합니다.");
        }
    }
}

