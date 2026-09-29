using System;

namespace Tuplas
{
    public class Program
    {
        static void Main(string[] args)
        {
            (int id, string name) product = (1, "cerveza stout");

            Console.WriteLine($"id: {product.id} nombre: {product.name}");

            product.name = "cerveza porter";

            Console.WriteLine($"id: {product.id} nombre : {product.name}");

            var person = (1, "Hector");

            Console.WriteLine($"id: {person.Item1} nombre : {person.Item2}");

            var people = new[]
            {
                (1, "Hector"),
                (2, "Pedro"),
                (3, "Juan")
            };

            foreach(var i in people)
            {
                Console.WriteLine("--Forach--");
                Console.WriteLine($"id: {i.Item1} nombre : {i.Item2}");
            }

            (int id, string name)[] people2 = new[]
            {
                (1, "Hector"),
                (2, "Ramon"),
                (3, "Roberto")
            };
            
            foreach( var p in people2)
            {
                Console.WriteLine("--Forach 2--");
                Console.WriteLine($"id: {p.id} nombre : {p.name}");
            }


        }
    }
}