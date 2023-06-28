using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Task_5
{

    public enum TypeLight
    {
        Daylight,
        Bicolor,
        Rgb
    }


    [Serializable]
    public class LoghtMonobloc
    {
        [JsonProperty("Name Light")]
        public string Name { get; set; }

        [JsonProperty("Light RCA")]
        public int Rca { get; set; }

        [JsonProperty("Type Light")]
        public TypeLight Light { get; set; }

        [JsonProperty("Min Photometrics")]
        public int MinPhotometrics { get; set; }

        [JsonProperty("Max Photometrics")]
        public int MaxPhotometrics { get; set; }

        public LoghtMonobloc(string name, int rca, TypeLight ling, int minPhotometrics, int maxPhotometrics)
        {
            Name = name;
            Rca = rca;
            Light = ling;
            MinPhotometrics = minPhotometrics;
            MaxPhotometrics = maxPhotometrics;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name Light: {Name};");
            Console.WriteLine($"Light RCA: {Rca};");
            Console.WriteLine($"Type Light: {Light};");
            Console.WriteLine($"Min Photometrics: {MinPhotometrics};");
            Console.WriteLine($"Max Photometrics: {MaxPhotometrics};");
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {

            LoghtMonobloc loght = new LoghtMonobloc("GF500", 93, TypeLight.Daylight, 2000, 10000);
            string file = JsonConvert.SerializeObject(loght, Formatting.Indented, new StringEnumConverter());

            Console.WriteLine(file);
            Console.ReadKey();

            LoghtMonobloc loght2;
            loght2 = JsonConvert.DeserializeObject<LoghtMonobloc>(file);
            Console.WriteLine(new String('-', 50));
            loght2.PrintInfo();
            Console.ReadKey();


            //или так:
            //FileStream stream = File.Create("CarData.data");
            //BinaryFormatter formatter = new BinaryFormatter();

            //formatter.Serialize(stream, loght);
            //stream.Close();

            //FileStream fs = File.Open("CarData.data", FileMode.Open);
            //LoghtMonobloc car = formatter.Deserialize(fs) as LoghtMonobloc;
            //fs.Close();

            //Console.ReadLine();


        }
    }
}
