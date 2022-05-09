namespace FUP
{
    // 파일 전송 요청 메시지(0x01)
    //  - 클라이언트에서 사용
    public class BodyRequest : ISerializable
    {
        // 전송할 파일 크기(단위:바이트)
        public long FILESIZE;

        // 전송할 파일의 이름
        public byte[] FILENAME;
        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            FILESIZE = BitConverter.ToInt64(bytes, 0);
            FILENAME = new byte[bytes.Length - sizeof(long)];
            Array.Copy(bytes, sizeof(long), FILENAME, 0, FILENAME.Length);
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            byte[] temp = BitConverter.GetBytes(FILESIZE);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            Array.Copy(FILENAME, 0, bytes, temp.Length, FILENAME.Length);

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(long) + FILENAME.Length;
        }
    }

    // 파일 전송 요청에 대한 응답 메시지(0x02)
    //  - 서버에서 사용
    //  - 클라이언트에서 보낸 파일 전송 요청(0x01) 메시지의 메시지 식별 번호와 같이 결과를 클라이언트에 전송
    public class BodyResponse : ISerializable
    {
        // 파일 전송 요청 메시지(0x01)의 메시지 식별 번호
        public uint MSGID;

        // 파일 전송 승인 여부
        //  - 0x0 : 거절
        //  - 0x1 : 승인
        public byte RESPONSE;
        public BodyResponse() { }
        public BodyResponse(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESPONSE = bytes[4];
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESPONSE;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }
    
    // 실제 파일을 전송하는 메시지(0x03)
    //  - 파일 전송 요청에 대한 응답(0x02) 메시지의 RESPONSE 필드가 0x1을 담고 클라이언트에 돌아오면, 클라이언트는 파일을 전송함.
    //  - 네트워크 전송에 알맞도록 잘 쪼개져서 파일 전송 데이터 메시지에 담겨 서버로 날아감
    //  - 마지막 전송 데이터 메시지는 헤더의 LASTMSG 필드에 0x01을 담아 보낸다.
    public class BodyData : ISerializable
    {
        // 파일 내용 (크기는 헤더의 BODYLEN)
        public byte[] DATA;
        public BodyData(byte[] bytes) 
        {
            DATA = new byte[bytes.Length];
            bytes.CopyTo(DATA, 0);  
        }
        public byte[] GetBytes()
        {
            return DATA;
        }

        public int GetSize()
        {
            return DATA.Length;
        }
    }

    // 파일 전송 결과 메시지(0x04)
    //  - 마지막 파일 전송 데이터 메시지를 수신하면 서버는 파일이 제대로 수신됐는지를 확인해서 파일 수신 결과(0x04) 메시지를 클라이언트에 보낸다.
    //  - 파일 전송 데이터(0x03) 메시지의 MSGID와 파일 수신 결과가 함께 담긴다.
    public class BodyResult : ISerializable
    {
        // 파일 전송 데이터(0x03)의 식별 번호
        public uint MSGID;

        // 파일 전송 성공 여부
        //  - 0x0 : 실패
        //  - 0x1 : 성공
        public byte RESULT;
        public BodyResult() { }
        public BodyResult(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes,0);
            RESULT = bytes[4];
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            bytes[temp.Length] = RESULT;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof (byte);
        }
    }
}
