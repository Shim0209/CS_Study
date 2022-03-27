using System;
using System.Linq;

/// LINQ의 비밀
/// - LINQ는 C#과 VB에서만 사용 가능하다. (2022.03 기준)
/// - LINQ 퀄리식이 실행될 수 있도록 CLR을 개선하는 대신, C# 컴파일러과 VB 컴파일러를 업그레이드 했다.
/// CLR이 이해할 수 있는 코드로 번역해주도록. LINQ 쿼리식을 분석해서 일반적인 메소드 호출 코드로 만든다.
/// - 절과 메소드
///     where => Where()
///     orderby => OrderBy()
///     select => Select()
///     from절의 범위 변수는 각 메소드에 입력되는 람다식의 매개변수
/// - from 절의 매개변수는 IEnumerable<T>의 파생 형식이어야 한다.
/// 
/// 
namespace SimpleLinq2
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfiles =
            {
                new Profile(){Name ="정우성", Height = 186},
                new Profile(){Name ="김태희", Height = 158},
                new Profile(){Name ="고현정", Height = 172},
                new Profile(){Name ="이문세", Height = 178},
                new Profile(){Name ="하하", Height = 171}
            };

            var profiles = arrProfiles.
                            Where(profile => profile.Height < 175).
                            OrderBy(profile => profile.Height).
                            Select(profile =>
                                new
                                {
                                    Name = profile.Name,
                                    InchHeight = profile.Height * 0.393
                                }
                            );

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}

