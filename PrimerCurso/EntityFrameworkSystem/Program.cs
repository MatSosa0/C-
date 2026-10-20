using System;
using BD.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NJB8MT2\\SQLEXPRESS;Database=csharpDB;User Id=admin;Password=123;TrustServerCertificate=True;");
            
            
            using (CsharpDbContext context = new CsharpDbContext(optionsBuilder.Options))
            {
                var beers = context.Beers.ToList();

                foreach (var beer in beers)
                {
                    Console.WriteLine($"Name: {beer.Name}, Brand ID: {beer.BrandId}");
                }
            }
        }
    }
}