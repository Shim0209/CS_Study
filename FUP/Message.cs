/// 파일 업로드 프로토콜 구현
/// - 직접 구현하는 File Upload Protocol (FUP)
/// 
/// 구조
/// - 바디에는 실제로 전달하고자 하는 데이터가 담겨있음 (크기는 데이터에 따라 달라짐)
/// - 헤더에는 본문 길이, 메시지의 속성 몇가지가 담겨있음 (크기는 16바이트 고정)
/// 
/// 사용법
/// 1. 수신한 패킷을 분석할 때는 가장 먼저 16바이트를 확인해서 메시지의 속성을 확인한다.
/// 2. 다음에 바디의 길이만큼을 또 읽어 하나의 메시지 끝을 끊어내야 한다.
/// 
/// 직렬화를 두고 왜 직접 프로토콜을 구현하는가?
/// - 이미 C, C++로 만들어져 사용되는 네트워크 애플리케이션과 어울리려면 이들이 지원하는 프로토콜을 지원해야 한다.
/// - C#의 직렬화 메커니즘으로는 해결할 수 없다.
namespace FUP
{
    public class CONSTANTS
    {
        // 메세지 타입 (MSGTYPE)
        public const uint REQ_FILE_SEND = 0x01;
        public const uint REP_FILE_SEND = 0x02;
        public const uint FILE_SEND_DATA = 0x03;
        public const uint FILE_SEND_RES = 0x04;

        public const byte NOT_FRAGMENTED = 0x00;
        public const byte FRAGMENTED = 0x01;

        public const byte NOT_LASTMSG = 0x00;
        public const byte LASTMSG = 0x01;

        public const byte ACCEPTED = 0x01;
        public const byte DENIED = 0x00;

        public const byte FAIL = 0x00;
        public const byte SUCCESS = 0x01;
    }

    /// 메세지, 헤더, 바디는 모두 이 인터페이스를 상속한다.
    /// 즉, 이들은 자신의 데이터를 바이트 배열로 변환하고 그 바이트 배열의 크기를 반환해야 한다.
    public interface ISerializable
    {
        byte[] GetBytes();
        int GetSize();
    }

    /// FUP의 메시지를 나타내는 클래스.
    /// Header와 Body로 구성된다.
    public class Message : ISerializable
    {
        public Header Header { get; set; }
        public ISerializable Body { get; set; }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            Header.GetBytes().CopyTo(bytes, 0);

            Body.GetBytes().CopyTo(bytes, Header.GetSize());

            return bytes;
        }

        public int GetSize()
        {
            return Header.GetSize() + Body.GetSize();
        }
    }
}
