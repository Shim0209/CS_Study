using System;
using System.Linq.Expressions;

/// 식 트리
/// - 식을 트리로 표현한 자료구조를 말한다.
/// - 하나의 부모 노드가 단 두개만의 자식 노드를 가질 수 있는 이진 트리 이다.
/// - 연산자는 부모 노드가 되며, 피연산자는 자식 노드가 된다.
/// - 식 트리 자료구조는 컴파일러나 인터프리터를 제작하는 데도 응용된다.
/// - 컴파일러는 프로그래밍 언어의 문법을 따라 작성된 코드를 분석해서 식 트리로 만든 후 이를 바탕으로 실행 파일을 만든다.
/// - 완전한 컴파일러는 아니지만, C#은 프로그래머가 C# 코드 안에서 직접 식 트리를 조립하고 컴파일해서 사용할 수 있는 기능을 제공한다.
/// - 다시말해, 프로그램 실행 중에 동적으로 무명함수를 만들어서 사용할 수 있게 해준다는 뜻이다.
/// 
namespace UsingExpressionTree
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 1*2+(x-y)
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2); // 1*2

            Expression param1 = Expression.Parameter(typeof(int)); // x를 위한 변수
            Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

            Expression rightExp = Expression.Subtract(param1, param2); // x-y

            Expression exp = Expression.Add(leftExp, rightExp);

            // 람다식 클래스의 파생 클래스인 Expression<TDelegate>를 사용
            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(exp, new ParameterExpression[]
            {
               (ParameterExpression) param1, (ParameterExpression)param2
            });

            Func<int, int, int> func = expression.Compile();

            // x = 7, y = 8
            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");



            /// 람다식을 이용해서 위의 예제와 같은 내용을 작성 ///
            Expression<Func<int, int, int>> expression1 = (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> func1 = expression1.Compile();

            // x = 7, y = 8
            Console.WriteLine($"1*2+({7}-{8}) = {func1(7, 8)}");
        }
    }
}

