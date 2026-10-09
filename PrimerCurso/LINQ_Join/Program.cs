using System;

namespace LINQ_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            var beers = new List<Beer>()
            {
                new Beer(){Name = "Corona", Country = "Mexico"},
                new Beer(){Name = "Heineken" , Country = "Alemania" },
                new Beer(){Name = "Budweiser" , Country = "USA" },
                new Beer(){ Name = "Minerva" , Country = "Mexico"}
            };

            var countries = new List<Country>()
            {
                new Country(){ Name = "Mexico", Continent = "America"},
                new Country(){ Name = "Alemania", Continent = "Europa"},
                new Country(){ Name = "USA", Continent = "America"}
            };

            var beerWithContinent = from b in beers
                                    join c in countries on b.Country equals c.Name
                                    select new 
                                    { 
                                        Name = b.Name, 
                                        Country = b.Country, 
                                        Continent =c.Continent 
                                    };
            
            foreach(var beer in beerWithContinent)
            {
                Console.WriteLine($"La cerveza {beer.Name} es de {beer.Country} y pertenece al continente {beer.Continent}");
            }
        }
    }
    class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return $"Name: {Name} Country: {Country}";
        }
    }

    class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }
    }
}