using System;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Beer MyBeer = new Beer() { Name = "Pikantus", Brand = "Erdinger" };

            string json = "{\"Name\": \"Pikantus\",\"Brand \": \"Erdinger\"}";

            Beer[] beers = new Beer[]
            {
                new Beer()
                {
                    Name = "Pikantus",
                    Brand = "Erdinger"
                },
                new Beer()
                {
                    Name = "Corona",
                    Brand = "Modelo"
                }
            };

            string json2 = "[" +
                "{\"Name\": \"Pikantus\",\"Brand \": \"Erdinger\"}," +
                "{\"Name\": \"Corona\",\"Brand \": \"Modelo\"}]";
        }

        public class Beer
        {
            public string Name { get; set; }
            public string Brand { get; set; }
        }
    }
}