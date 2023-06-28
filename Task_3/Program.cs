using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_3
{

    public class User
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public User()
        {
        }

        public User(string name, string fullName, int age)
        {
            Name = name;
            FullName = fullName;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name};");
            Console.WriteLine($"Фамилия: {FullName};");
            Console.WriteLine($"Вік: {Age};");
        }

    }

    [XmlRoot("MyUser")]
    public class UserCastom
    {

        [XmlAttribute("UName")]
        public string Name { get; set; }

        [XmlAttribute("UFullName")]
        public string FullName { get; set; }

        [XmlAttribute("UAge")]
        public int Age { get; set; }

        public UserCastom()
        {
        }

        public UserCastom(string name, string fullName, int age)
        {
            Name = name;
            FullName = fullName;
            Age = age;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name};");
            Console.WriteLine($"Фамилия: {FullName};");
            Console.WriteLine($"Вік: {Age};");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            User user1;
            UserCastom user2;

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            FileStream sile = File.Open("file-bas.xml", FileMode.Open);


            user1 = serializer.Deserialize(sile) as User;
            user1.PrintInfo();

            Console.WriteLine(new String('-', 50));



            XmlSerializer serializer2 = new XmlSerializer(typeof(UserCastom));
            FileStream sile2 = File.Open("file-Atr.xml", FileMode.Open);


            user2 = serializer2.Deserialize(sile2) as UserCastom;
            user2.PrintInfo();

            Console.ReadKey();
        }
    }
}
