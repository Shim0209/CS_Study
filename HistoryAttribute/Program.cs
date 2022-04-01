using System;

/// 내가 만드는 애트리뷰트
/// - .NET이 제공하는 애트리뷰트는 Obsolete 말고도 그 종류가 상당히 많다. 
/// - 애트리뷰트는 그 수만큼이나 사용 방법도 다양하다. 그래서 일일이 알아보는 대신 직접 만들어서 사용한다.
/// 
/// 직접 만드는 방법
/// - System.Attribute 클래스로부터 상속을 받아 만든다.
/// - 애트리뷰트를 중복해서 사용하기 위해서는 System.AttributeUsage를 사용해야한다.
namespace HistoryAttribute
{
    // 애트리뷰트 중복 사용을 위한 System.AttributeUsage 사용, 타겟은 논리합 연산자를 이용해서 결합할 수 있다.
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    // 직접만든 애트리뷰트
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "First release";
        }

        public string GetProgrammer()
        {
            return programmer;
        }
    }

    // 애트리뷰트 사용
    [History("Shim", version = 0.1, changes = "2022-03-31 Created class HistoryAttribute")]
    [History("Tao", version = 0.2, changes = "2022-03-31 Added func() GetProgrammer()")]
    class MyClass
    {
        public void Func()
        {
            Console.WriteLine("Func()");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            Console.WriteLine("MyClass change history...");

            foreach(Attribute a in attributes)
            {
                History h = a as History;
                if (h != null)
                    Console.WriteLine($"Ver:{h.version}, Programmer:{h.GetProgrammer()}, Changes:{h.changes}");
            }
        }
    }
}
