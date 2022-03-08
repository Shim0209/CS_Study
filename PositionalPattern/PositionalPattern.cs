using static System.Console;

namespace PositionalPattern
{
    class MainApp
    {
        private static double GetDiscountRate(object client)
        {
            return client switch
            {
                ("학생", int n) when n < 18 => 0.2,
                ("학생", _) => 0.1,
                ("일반", int n) when n < 18 => 0.1,
                ("일반", _) => 0.05,
                _ => 0,
            };
        }
        static void Main(string[] args)
        {
            var alice = (job: "학생", age: 17);
            var bob = (job: "학생", age: 23);
            var charlie = (job: "일반", age: 15);
            var dave = (job: "일반", age: 21);

            WriteLine($"alice   :{GetDiscountRate(alice)}");
            WriteLine($"bob   :{GetDiscountRate(bob)}");
            WriteLine($"charlie   :{GetDiscountRate(charlie)}");
            WriteLine($"dave   :{GetDiscountRate(dave)}");
        }
    }
}

