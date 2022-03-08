using static System.Console;

/**
 * 배열을 초기화하는 3가지 방법
 */
namespace InitializingArray
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 1.
            string[] array1 = new string[3] { "안녕", "Hello", "Halo" };

            // 2.
            string[] array2 = new string[] { "안녕", "Hello", "Halo" };

            // 3.
            string[] array3 = { "안녕", "Hello", "Halo" };

        }
    }
}

