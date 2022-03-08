using static System.Console;

/**
 *                클래스               구조체
 *  키워드         class               struct
 *  형식          참조형식(힙)          값형식(스택)
 *  복사          얇은복사              깊은복사
 *  인스턴스 생성  new연산자와 생성자    선언만으로
 *  생성자        매개변수없이가능       매개변수없이불가
 *  상속          가능                  값 형식이므로 상속 불가
 */
namespace Structure
{
    struct Point3D
    {
        public int x;
        public int y;
        public int z;

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y; 
            this.z = z; 
        }

        public override string ToString()
        {
            return string.Format($"{x}, {y}, {z}");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Point3D point3D; // 선언만으로 인스턴스 생성
            point3D.x = 10;
            point3D.y = 20;
            point3D.z = 40;

            WriteLine(point3D.ToString());

            Point3D point3D1 = new Point3D(100, 200, 400); // 생성자로 인스턴스 생성
            Point3D point3D2 = point3D1; // 깊은복사
            point3D2.z = 500;

            WriteLine(point3D1.ToString());
            WriteLine(point3D2.ToString());

        }
    }
}

