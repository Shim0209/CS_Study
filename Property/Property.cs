using System;
using static System.Console;

/**
 * 프로퍼티
 * 기존에 private 필드를 set, get 메소드를 이용해서 접근했던 방식을 계선한 c# 문법
 * private int myField;
 * public int MyField
 * {
 *      get
 *      {
 *          return myField;
 *      }
 *      
 *      set // 생략시 읽기전용
 *      {
 *          myField = value;
 *      }
 * }
 */
namespace Property
{
    // 일반 프로퍼티
    /*
    class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
            }
        }
    }
    */

    // 자동 프로퍼티
    class BirthdayInfo
    {
        public string Name { get; set; } = "UnKnown";
        public DateTime Birthday { get; set; } = new DateTime(1,1,1);
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birthday = new BirthdayInfo();
            Console.WriteLine($"Name : {birthday.Name}");
            Console.WriteLine($"Birthday {birthday.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age : {birthday.Age}");

            birthday.Name = "서현";
            birthday.Birthday = new DateTime(1991, 6, 28);

            Console.WriteLine($"Name : {birthday.Name}");
            Console.WriteLine($"Birthday {birthday.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age : {birthday.Age}");

            // 프로퍼티와 생성자
            BirthdayInfo birth = new BirthdayInfo()
            {
                Name = "유리",
                Birthday = new DateTime(1990, 3, 5)
            };

            Console.WriteLine($"Name : {birth.Name}");
            Console.WriteLine($"Birthday {birth.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age : {birth.Age}");
        }
    }
}

