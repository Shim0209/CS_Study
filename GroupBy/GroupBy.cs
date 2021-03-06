using static System.Console;

/// 데이터 그룹화
/// - group (from 절에서 뽑아낸 범위변수) by (분류기준) into (그룹변수)
namespace GroupBy
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
            Profile[] profiles =
            {
                new Profile(){Name = "정우성", Height = 186},
                new Profile(){Name = "김태희", Height = 158},
                new Profile(){Name = "고현정", Height = 172},
                new Profile(){Name = "이문세", Height = 178},
                new Profile(){Name = "하하", Height = 171}
            };

            var listProfile = from profile in profiles
                              orderby profile.Height
                              group profile by profile.Height < 175 into g
                              select new { GroupKey = g.Key, Profile = g };

            foreach (var Group in listProfile)
            {
                Console.WriteLine($"- 175cm 미만 : {Group.GroupKey}");
                foreach (var profile in Group.Profile)
                {
                    Console.WriteLine($">>> {profile.Name}, {profile.Height}");
                }
            }
        }
    }
}

