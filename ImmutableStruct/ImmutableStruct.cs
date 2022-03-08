using System;
using static System.Console;

/**
 * 변경불가능한 객체
 * - 상태의 변화를 허용하지 않는 객체
 * - 효용
 * 1. 멀티 쓰레드 간에 동기화를 할 필요가 없기 때문에 프로그램 성능 향상이 가능
 * 2. 버그로 인한 상태(데이터)의 오염을 막을 수 있다.
 */
namespace ImmutableStruct
{
    readonly struct RGBColor
    {
        public readonly byte R;
        public readonly byte G;
        public readonly byte B; 

        public RGBColor(byte r, byte g, byte b) // 변경불가능한 객체는 생성자에서만 초기화 가능
        {
            R = r;
            G = g;
            B = b;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            RGBColor Red = new RGBColor(255, 0, 0);
            Red.G = 100; // 변경불가능한 객체로 컴파일 에러 발생
        }
    }
}

