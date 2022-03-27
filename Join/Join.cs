using System;
using System.Linq;

/// 내부조인
/// - 내부 조인은 join 절을 통해서 수행된다.
/// - join 절의 on 키워드는 조인 조건을 수반한다. 이때 on 절의 조인 조건은 equals만 허용된다.
/// 
/// 외부조인
/// - 내부 조인과 비슷하지만, 조인 결과에 기준이 되는 데이터 원본이 모두 포함된다는 점이 다르다.
/// - join절을 이용해서 조인을 수행한 후 그 결과를 임시 컬렉션에 저장(여기서는 ps), 임시 컬렉션에 대해
/// DefaultEmpty 연산을 수행해서 비어 있느 ㄴ조인 결과에 빈 값을 채워 넣는다. DefaultEmpty 연산을 거친
/// 임시 컬렉션에서 from 절을 통해 범위 변수를 뽑아내고, 이 범위 변수와 기준 데이터 원본에서 뽑아낸 범위
/// 변수를 이용해서 결과를 추출한다.
namespace Join
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
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

            Product[] arrProducts =
            {
                new Product(){Title = "비트", Star = "정우성"},
                new Product(){Title = "하이바이마마", Star = "김태희"},
                new Product(){Title = "아이리스", Star = "김태희"},
                new Product(){Title = "모래시계", Star = "고현정"},
                new Product(){Title = "솔로예찬", Star = "이문세"}
            };

            var listProfile = from profile in arrProfiles
                              join product in arrProducts on profile.Name equals product.Star
                              select new
                              {
                                  Name = profile.Name,
                                  Work = product.Title,
                                  Height = profile.Height
                              };

            Console.WriteLine("--- 내부 조인 결과 ---");
            foreach (var profile in listProfile)
            {
                Console.WriteLine($"이름:{profile.Name}, 작품:{profile.Work}, 키:{profile.Height}");
            }

            listProfile = from profile in arrProfiles
                          join product in arrProducts on profile.Name equals product.Star into ps
                          from product in ps.DefaultIfEmpty(new Product() { Title = "없음" })
                          select new
                          {
                              Name = profile.Name,
                              Work = product.Title,
                              Height = profile.Height
                          };
            Console.WriteLine();
            Console.WriteLine("--- 외부 조인 결과 ---");
            foreach (var profile in listProfile)
            {
                Console.WriteLine($"이름:{profile.Name}, 작품:{profile.Work}, 키:{profile.Height}");
            }
        }
    }
}

