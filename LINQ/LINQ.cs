using System;
using System.Linq;

/// LINQ
/// - Language INtegrated Query의 약어로, C# 언어에 통합된 질의 기능을 말한다.
/// - 모든 LINQ 쿼리식은 반드시 from 절로 시작한다.
/// - from의 데이터 원본은 아무 형식이나 사용할 수 없고, IEnumerable<T> 인터페이스를 상속하는 형식이어야 한다.
/// - from n in numbers에서 범위변수 n은 실제로 데이터를 담지 않는다. 어로지 어떤 일이 일어날지를 묘사하기 위함. 즉, foreach에서의 반복 변수와 다르다.
/// 
namespace LINQ
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
            
            Profile[] arrProfile =
            {
                new Profile(){Name = "나연", Height = 162},
                new Profile(){Name = "모모", Height = 165},
                new Profile(){Name = "사나", Height = 167},
                new Profile(){Name = "지효", Height = 159},
                new Profile(){Name = "미나", Height = 163}
            };

            // LINQ를 모르는 경우
            List<Profile> profiles = new List<Profile>();
            foreach (Profile profile in arrProfile)
            {
                if(profile.Height < 163)
                    profiles.Add(profile);
            }

            profiles.Sort(
                (profile1, profile2) =>
                {
                    return profile1.Height - profile2.Height;
                });

            foreach (var profile1 in profiles)
                Console.WriteLine($"{profile1.Name}, {profile1.Height}");

            // LINQ를 아는 경우
            var profiles1 = from profile in arrProfile
                            where profile.Height < 163
                            orderby profile.Height
                            select profile;

            foreach (var profile1 in profiles1)
                Console.WriteLine($"{profile1.Name}, {profile1.Height}");
        }
    }
}

