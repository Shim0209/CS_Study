using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

/// 리플렉션
/// 
/// 

/// int 형식의 주요 정보(상속하는 인터페이스, 필드, 메소드, 프로퍼티 등)를 출력하는 예제 프로그램
namespace GetType
{
    class MainApp
    {
        // 인터페이스 정보를 출력
        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("-------- Interfaces --------");

            Type[] interfaces = type.GetInterfaces();
            foreach (Type i in interfaces)
                Console.WriteLine($"Name:{i.Name}");

            Console.WriteLine();
        }

        // 필드 정보를 출력
        static void PrintFields(Type type)
        {
            Console.WriteLine("-------- Fields --------");

            // 퍼블릭, 논퍼블릭, 스태픽, 인스턴스 옵션 선택 가능
            FieldInfo[] fields = type.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                String accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine($"Access:{accessLevel}, Type:{field.FieldType.Name}, Name:{field.Name}");
            }

            Console.WriteLine();
        }

        // 메소드 정보를 출력
        static void PrintMethods(Type type)
        {
            Console.WriteLine("-------- Methods --------");

            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.Write($"Return type:{method.ReturnType.Name}, Name:{method.Name}, Parameter:");
                ParameterInfo[] parameters = method.GetParameters();
                for(int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name}");
                    if (i < parameters.Length - 1)
                        Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        // 프로퍼티 정보를 출력
        static void PrintProperties(Type type)
        {
            Console.WriteLine("-------- Properties --------");

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
                Console.WriteLine($"Type:{property.PropertyType.Name}, Name:{property.Name}");

            Console.WriteLine();
        }

        // 생성자 정보를 출력
        static void PrintConstructors(Type type)
        {
            Console.WriteLine("-------- Constructor --------");

            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
                Console.WriteLine($"Type:{constructor.DeclaringType.Name}, Name:{constructor.Name}");

            Console.WriteLine();
        }

        // 내부형식 정보를 출력
        static void PrintNestedTypes(Type type)
        {
            Console.WriteLine("-------- NestedTypes --------");

            // ???

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //int a = 0;
            String a = "";
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintFields(type);
            PrintMethods(type);
            PrintProperties(type);
            PrintConstructors(type);
        }
    }
}

