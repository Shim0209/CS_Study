using System;

namespace FUP
{
    /// Header
    public class Header : ISerializable
    {
        // 메시지 식별 번호
        public uint MSGID { get; set; }
        
        // 메시지의 종류
        //  - 0x01 : 파일 전송 요청
        //  - 0x02 : 파일 전송 요청에 대한 응답
        //  - 0x03 : 파일 전송 데이터
        //  - 0x04 : 파일 수신 결과
        public uint MSGTYPE { get; set; }
        
        // 메시지 본문의 길이(단위: 바이트)
        public uint BODYLEN { get; set; }

        // 메시지의 분할 여부
        //  - 0x0 : 미분할
        //  - 0x1 : 분할
        public byte FRAGMENTED { get; set; }

        // 분할된 메시지가 마지막인지 여부
        //  - 0x0 : 마지막 아님
        //  - 0x1 : 마지막
        public byte LASTMSG { get; set; }   

        // 메시지의 파편 번호
        public ushort SEQ { get; set; }

        public Header() { }
        public Header(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            MSGTYPE = BitConverter.ToUInt32(bytes, 4);
            BODYLEN = BitConverter.ToUInt32(bytes, 8);
            FRAGMENTED = bytes[12];
            LASTMSG = bytes[13];
            SEQ = BitConverter.ToUInt16(bytes, 14);
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[16];

            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            temp = BitConverter.GetBytes(MSGTYPE);
            Array.Copy(temp, 0, bytes, 4, temp.Length);

            temp = BitConverter.GetBytes(BODYLEN);
            Array.Copy(temp, 0, bytes, 8, temp.Length);

            bytes[12] = FRAGMENTED;
            bytes[13] = LASTMSG;

            temp = BitConverter.GetBytes(SEQ);
            Array.Copy(temp, 0, bytes, 14, temp.Length);

            return bytes;
        }

        public int GetSize()
        {
            return 16;
        }
    }
}
