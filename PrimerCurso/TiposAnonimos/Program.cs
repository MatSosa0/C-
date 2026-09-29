using System;
using System.Threading.Channels;

namespace TiposAnonimos
{
    class Program
    {
        static void Main(string[] args)
        {
            var hector = new { Name = "Hector", Country = "Mexico" };

            Console.WriteLine($"Nombre: {hector.Name}, Pais: {hector.Country}");

            //hector.Name = "Juan"; // Los objetos anonimos son inmutables, por lo que no se puede cambiar el valor de sus propiedades

            var beers = new[]
            {
                new { Name = "Red", Brad= "Delirium"},
                new { Name = "London Porter", Brad= "Fullers"}
            };

            foreach(var b in beers)
            {
                Console.WriteLine($" Mi cerveza {b.Name} de la marca {b.Brad}");
            }
        }

    }
}