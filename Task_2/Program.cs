using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Task_2
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


    public class Program
    {
        static void Main(string[] args)
        {

            User user1 = new User("Wolte", "Wate", 34);
            UserCastom user2 = new UserCastom("Jon", "Rijer", 67);


            Console.WriteLine("User1:");
            user1.PrintInfo();
            Console.WriteLine(new String('-',50));

            XmlSerializer serializer = new XmlSerializer(typeof(User));

            FileStream filexml = new FileStream("file-bas.xml", FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(filexml, user1);


            filexml.Close();



            Console.WriteLine("User2:");
            user2.PrintInfo();
            Console.WriteLine(new String('-', 50));

            XmlSerializer serializer2 = new XmlSerializer(typeof(UserCastom));

            FileStream filexml2 = new FileStream("file-Atr.xml", FileMode.OpenOrCreate, FileAccess.Write);


            serializer2.Serialize(filexml2, user2);
            filexml2.Close();




            Console.ReadKey();

        }
    }
}
