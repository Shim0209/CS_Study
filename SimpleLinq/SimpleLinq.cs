using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLinq
{
    class Profile
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){ Name = "제니", Age = 23},
                new Profile(){ Name = "지수", Age = 25},
                new Profile(){ Name = "로제", Age = 22},
                new Profile(){ Name = "리사", Age = 21}
            };

            var profiles = from profile in arrProfile
                           where profile.Age < 22
                           orderby profile.Age
                           select new
                           {
                               Name = profile.Name,
                               Age = profile.Age * 0.9
                           };

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.Age}");
        }
    }
}

