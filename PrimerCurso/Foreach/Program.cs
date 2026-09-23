using System;
using System.Collections.Generic;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>
            {
                1,2,34,5,67,78
            };

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            var people = new List<People>()
            {
                new People(){Name = "Jhon", Country = "USA"},
                new People(){Name = "Marie", Country = "UK"},
                new People(){Name = "Roberto", Country = "PY"}
            };

            Show(people);

            people.RemoveAt(0);
            Show(people);
        }

        static void Show(List<People> students)
        {
            Console.WriteLine("--Personas--");
            foreach(var people in students)
            {
                Console.WriteLine($"Nombre: {people.Name}, Pais: {people.Country}");
            }
        }
    }

    class People
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}