using System;
using System.Linq;
namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Beer> beers = new List<Beer>()
             {
                 new Beer(){ Name = "Heineken", Country = "Alemania" },
                 new Beer(){ Name = "Delirium", Country = "Belgica"},
                 new Beer(){ Name = "Corona", Country = "Mexico"}
             }; 
            
            foreach(var beer in beers)
            {
                Console.WriteLine(beer);
            }

            Console.WriteLine("-----------------------------------");

            // Select

            var beerName = from b in beers
                           select new
                           {
                               Name = b.Name,
                               Letters = b.Name.Length,
                               Fixed = 1
                           };

            foreach (var name in beerName)
            {
                Console.WriteLine($"Name: {name.Name} Letters: {name.Letters} Fixed: {name.Fixed}");
            }

            Console.WriteLine("-----------------------------------");

            var beersNameReal = from b in beerName
                                select new
                                {
                                    Name = b.Name
                                };

            foreach(var name in beersNameReal)
            {
                Console.WriteLine(name.Name);
            }

            Console.WriteLine("------------------------------------");

            var beersMexico = from b in beers
                              where b.Country == "Mexico" || b.Country == "Alemania"
                              select b;
            foreach(var beer in beersMexico)
            {
                Console.WriteLine(beer);
            }

            Console.WriteLine("--------------------------------------");

            var orderedBeers = from b in beers
                               orderby b.Country
                               select b;
            foreach(var beer in orderedBeers)
            {
                Console.WriteLine(beer);
            }
        }

        public class Beer
        {
            public string Name { get; set; }
            public string Country { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Country: {Country}";
            }
        }
    }
}