using System;
using System.Net.Cache;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            People matias = new People()
            {
                Name = "Matias",
                Age = 28
            };

            People roberto = new People() {Name = "Roberto",Age = 35};

            Console.WriteLine(People.count);
            Console.WriteLine(People.GetCount()); 
        }
    }

    public static class A
    {
        public static void Some()
        {
            Console.WriteLine("algo");
        }
    }

    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public static int count = 0;

        public People()
        {
            count++;
        }

        public static string GetCount()
        {
            return $"Esta clase se ha utilizado {count} veces";
        }
    }
}