using static System.Console;

namespace StringSlice

{
    class MainApp
    {
        static void Main(String[] args)
        {
            string greeting = "Good Morning";

            WriteLine(greeting.Substring(0, 5));
            WriteLine(greeting.Substring(5));
            WriteLine();

            string[] arr = greeting.Split(new string[] { " " }, StringSplitOptions.None);
            WriteLine("Word Count : {0}", arr.Length);

            foreach (string item in arr)
                WriteLine("{0}", item);
        }
    }
}
