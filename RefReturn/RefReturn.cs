using static System.Console;

namespace RefReturn
{
    class Product
    {
        int price = 100;

        public ref int GetPrice()
        {
            return ref price;
        }

        public void PrintPrice()
        {
            Console.WriteLine($"Price: {price}");
        }
    }
    class MainApp
    {
        
        static void Main(string[] args)
        {
            Product apple = new Product();
            ref int ref_local_price = ref apple.GetPrice();
            int normal_local_price = apple.GetPrice();

            apple.PrintPrice();
            WriteLine($"Ref Local Price: {ref_local_price}");
            WriteLine($"Normal Local Price: {normal_local_price}");

            ref_local_price = 300;

            apple.PrintPrice();
            WriteLine($"Ref Local Price: {ref_local_price}");
            WriteLine($"Normal Local Price: {normal_local_price}");
        }
    }
}

