using static System.Console;

namespace PropertiesInInterface
{
    interface INamedValue
    {
        string Name { get; set; }
        string Value { get; set; }
    }

    class NamedValue : INamedValue
    {
        // INamedValue인터페이스의 Name, Value를 구현해야한다.
        // 이때 자동프로퍼티를 이용할수도 있다.
        public string Name { get; set; }
        public string Value { get; set; }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue()
            {
                Name = "이름", Value = "용용이"
            };

            NamedValue height = new NamedValue()
            {
                Name = "키", Value = "177cm"
            };

            NamedValue width = new NamedValue()
            {
                Name = "몸무게",
                Value = "98kg"
            };

            Console.WriteLine($"{name.Name} : {name.Value}");
            Console.WriteLine($"{height.Name} : {height.Value}");
            Console.WriteLine($"{width.Name} : {width.Value}");
        }
    }
}

