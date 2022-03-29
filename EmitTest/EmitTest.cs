using System;
using System.Reflection;
using System.Reflection.Emit;

/// 형식 내보내기
/// - C#에서는 프로그램 실행중에 새로운 형식을 만들어낼 수 있는 기능도 제공한다.
/// - 리플렉션에서의 Emit은 프로그램이 실행 중에 만들어낸 새 형식을 CLR의 메모리에 "내보낸다"는 의미로 사용된다.
/// - 사용순서 (어셈블리 -> 모듈 -> 클래스 -> 메소드 또는 프로퍼티)
///     1. AssemblyBuilder를 이용해서 어셈블리를 만든다.
///     2. ModuleBuilder를 이용해서 1에서 생성한 어셈블리 안에 모듈을 만들어 넣는다.
///     3. 2에서 생성한 모듈 안에 TypeBuilder로 클래스(형식)을 만들어 넣는다.
///     4. 3에서 생성한 클래스 안에 메소드(MethodBuilder 이용)나 프로퍼티(PropertyBuilder 이용)를 만들어 넣는다.
///     5. 4에서 생성한 것이 메소드라면, ILGenerator를 이용해서 메소드 안에 CPU가 실행할 IL명령들을 넣는다.

namespace EmitTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 어셈블리 생성
            AssemblyBuilder newAssembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("CalculatorAssembly"), AssemblyBuilderAccess.Run);

            // 모듈 생성
            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");

            // 클래스 생성
            TypeBuilder newType = newModule.DefineType("Sum1To100");

            // 메소드 생성
            MethodBuilder newMethod = newType.DefineMethod("Calculate", MethodAttributes.Public, typeof(int), new Type[0]); // 메소드명 Calculate, 퍼블릭, 반환타입 int, 매개변수 없음

            // 메소드가 실행할 코드 생성
            ILGenerator generator = newMethod.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1);      // 32비트 정수 1을 계산 스택에 넣는다.

            for(int i = 2; i<=100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);  // 32비트 정수 i를 계산 스택에 넣는다.
                generator.Emit(OpCodes.Add);        // 계산 후 계산 스택에 담겨 있는 두 개의 값을 꺼내서 더한 후, 그 결과를 다시 계산 스택에 넣는다.
            }

            generator.Emit(OpCodes.Ret);            // 계산 스택에 담겨 있는 값을 반환한다.
            newType.CreateType();
            //////////// 여기까지 새로운 형식을 만드는 과정 //////////






            /// 위 형식의 인스턴스를 동적으로 생성해서 이용할 수 있다.
            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }
}

