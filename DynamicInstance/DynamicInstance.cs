using System;
using System.Reflection;

/// 리플렌셕을 이용한 객체 생성 및 이용
/// - 리플렉션을 이용해서 동적으로 객체를 만들 수 있다. (Activator.CreateInstance())
/// - 객체의 프로퍼티값을 동적으로 할당 할 수 있다. (PropertyInfo의 GetValue(), SetValue(해당 객체, 매개변수, 인덱서))
/// - 메소드를 동적으로 호출 할 수 있다 (MethodInfo의 Invoke(해당 객체, 매개변수))
namespace DynamicInstance
{
    class Profile
    {
        private string name;
        private string phone;
        public Profile()
        {
            name  = "";
            phone  = "";
        }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void Print()
        {
            Console.WriteLine($"{name}, {phone}");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            // 타입을 알아내기
            Type type = Type.GetType("DynamicInstance.Profile");
            // 알아낸 타입에서 Print 메소드 얻기
            MethodInfo methodInfo = type.GetMethod("Print");
            // 알아낸 타입에서 Name, Phone 프로퍼티 얻기
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            // 알아낸 타입으로 동적인스턴스 생성(초기화o)
            object profile = Activator.CreateInstance(type, "나연", "1234");
            // 동적으로 생성된 인스턴스에서 동적으로 메소드 호출
            methodInfo.Invoke(profile, null);

            // 새로운 동적인스턴스 생성(초기화x)
            profile = Activator.CreateInstance(type);
            // 동적으로 프로퍼티 생성
            nameProperty.SetValue(profile, "웬디", null);
            phoneProperty.SetValue(profile, "5678", null);

            Console.WriteLine($"{nameProperty.GetValue(profile, null)}, {phoneProperty.GetValue(profile, null)}");
        }
    }
}

