using static System.Console;

/**
 * 읽기 전용 필드는 readonly 키워드를 이용해 선언
 * 생성자 안에서만 초기화가 가능하며, 생성자가 아닌 메서드에서
 * 수정하려는 시도가 발생하면 컴파일 에러가 발생.
 */
namespace ReadonlyFields
{
    class Configuration
    {
        private readonly int min;
        private readonly int max;

        // 생성자에서 초기화
        public Configuration(int v1, int v2)
        {
            min = v1;
            max = v2;
        }

        public void ChangeMax(int newMax)
        {
            max = newMax; // 컴파일 에러
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration(10, 100);
        }
    }
}

