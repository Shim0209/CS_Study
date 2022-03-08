using static System.Console;

namespace NamedParameter
{
    class MainApp
    {
        static void PrintProfile(string name, string phone)
        {
            WriteLine($"Name: {name}, Phone: {phone}");
        }
        static void Main(string[] args)
        {
            PrintProfile(name: "심연성", phone: "010-5697-5522");
            PrintProfile(phone: "010-3976-0011", name: "심연성1" );
            PrintProfile("심연성2", "010-1111-2222");
            PrintProfile("010-3333-5555", "심연성3");
        }
    }
}

