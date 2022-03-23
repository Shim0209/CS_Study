using System;

/// 문 형식의 람다식
/// - => 오른편에 식 대신 {}로 둘러싸인 블록이 위치
/// - 반환 형식이 없어도 된다.
/// 
namespace StatementLambda
{
    class MainApp
    {
        delegate string Concatenate(string[] args);
        static void Main(string[] args)
        {
            string[] str = { "아버지가", "방에", "들어가신다." };

            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;
                return result;
            };

            Console.WriteLine(concat(str));
        }
    }
}

