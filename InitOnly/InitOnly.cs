using static System.Console;

/**
 * 초기화 전용 자동 구현 프로퍼티
 * - 생성자를 통해서 필드를 초기화하고 필드에 접근은 get으로만 하도록 함.
 * - 효용
 *      - 초기화가 한 차례 이루어진 후 변경되면 안되는 데이터에 사용
 *      - 성적표, 범죄 기록, 각종 국가 기록, 금융 거래 등등
 */
namespace InitOnly
{
    class Transaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100 };
            Transaction tr2 = new Transaction { From = "Bob", To = "Chalie", Amount = 50 };
            Transaction tr3 = new Transaction { From = "Chalie", To = "Alice", Amount = 50 };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine(tr3);
        }
    }
}

