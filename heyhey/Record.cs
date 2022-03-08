using static System.Console;

/**
 * Record
 * - 레코드 형식으로 만드는 불변 객체
 * - 불변 참조 객체
 * - struct를 사용하는 value type과 class를 사용하는 reference type이 있는데, 
 *  record는 객체 내의 멤버가 변하지 않는 immutable reference type이다.
 *  
 * with
 * - 객체 중 일부만 변경하여 새로운 객체를 만들고 싶을때 사용
 * 
 * record 객체비교
 * - 컴파일러는 레코드의 상태를 비교하는 Equals() 메소드를 자동으로 구현한다.
 *      - class는 Equals()를 오버라이딩해서 구현해야 하지만, 레코드는 참조형식임에도
 *       자동으로 구현되어 사용할 수 있다.
 * - record타입의 Equals() -> bool값 반환
 * - 객체의 reference 비교 ReferenceEquals() -> bool값 반환
 */
namespace Record
{
    record RTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }
        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }
    class CTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override bool Equals(object? obj)
        {
            CTransaction target = (CTransaction)obj;

            if(this.From == target.From && this.To == target.To && this.Amount == target.Amount)
                return true;
            else 
                return false;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            RTransaction tr1 = new RTransaction()
            {
                From =  "Alice", To = "Bob", Amount = 100
            };

            RTransaction tr2 = new RTransaction()
            {
                From = "Alice", To = "Chalie", Amount = 100
            };

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);

            // with를 이용한 레코드 복사
            RTransaction tr3 = tr2 with {To = "Shim"};
            Console.WriteLine(tr3);

            // 객체 비교
            // class
            CTransaction trA = new CTransaction { From = "A", To = "B", Amount = 100 };
            CTransaction trB = new CTransaction { From = "A", To = "B", Amount = 100 };
            Console.WriteLine(trA.Equals(trB));
            // record
            RTransaction trC = new RTransaction { From = "A", To = "B", Amount = 100 };
            RTransaction trD = new RTransaction { From = "A", To = "B", Amount = 100 };
            Console.WriteLine(trC.Equals(trD));
        }
    }
}

