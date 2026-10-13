using System;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BeerDB db = new BeerDB(@"DESKTOP-NJB8MT2\SQLEXPRESS", "csharpDB", "admin", "123");

                List<Beer> beers = db.GetBeers();

                foreach (var b in beers)
                {
                    Console.WriteLine(b.Name);
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("No pudimos conectarnos");
            }
        }
    }
}