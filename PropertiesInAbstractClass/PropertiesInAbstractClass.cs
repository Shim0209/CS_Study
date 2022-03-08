using static System.Console;

namespace PropertiesInAbstractClass
{
    abstract class Product
    {
        private static int serial = 0;
        public string SerialID // 구현을 가진 프로퍼티
        {
            get { return String.Format("{0:d5}", serial++); }
        }

        abstract public DateTime ProductDate // 구현이 없는 프로퍼티
        {
            get; set;
        }
    }

    class MyProduct : Product
    {
        public override DateTime ProductDate // 파생클래스는 추상클래스의 모든 추상메소드, 추상프로퍼티를 재정의해야함
        { 
            get;
            set; 
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Product product = new MyProduct()
            {
                ProductDate = new DateTime(2018, 1, 10)
            };

            Console.WriteLine("Product:{0}, Product Date:{1}", product.SerialID, product.ProductDate);

            Product product2 = new MyProduct()
            {
                ProductDate = new DateTime(2018, 2, 3)
            };
            Console.WriteLine("Product:{0}, Product Date:{1}", product2.SerialID, product2.ProductDate);
        }
    }
}

