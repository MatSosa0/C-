using System;
using BD.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EntityFrameworkSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<CsharpDbContext> optionsBuilder = new DbContextOptionsBuilder<CsharpDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-NJB8MT2\\SQLEXPRESS;Database=csharpDB;User Id=admin;Password=123;TrustServerCertificate=True;");

            bool again = true;
            int op = 0;

            do
            {
                ShowMenu();
                Console.WriteLine("Elige una opcion: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1 :
                        Show(optionsBuilder);
                        break;
                    case 2:
                        Add(optionsBuilder);
                        break;
                        
                }


            } while (again);
            
        }

        public static void Add(DbContextOptionsBuilder<CsharpDbContext> optionBuilder)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva Cerveza");
            Console.WriteLine("Escribe el nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el ID de la marca: ");
            int brandId = int.Parse(Console.ReadLine());
            using (var context = new CsharpDbContext(optionBuilder.Options))
            {
                Beer beer = new Beer()
                {
                    Name = name,
                    BrandId = brandId
                };
                context.Add(beer);
                context.SaveChanges();
            }
        }
        public static void Show(DbContextOptionsBuilder<CsharpDbContext> optionBuilder)
        {
            Console.Clear();
            Console.WriteLine("Cervezas de la base de datos");
            using (var context = new CsharpDbContext(optionBuilder.Options))
            {
                List<Beer> beers = context.Beers.OrderBy(b => b.Name).ToList();
                List<Beer> beers2 = (from b in context.Beers
                                     orderby b.Name
                                     select b).Include(b=>b.Brand).ToList() ;
                foreach(var beer in beers2)
                {
                    Console.WriteLine($"{beer.Id} - {beer.Name} - {beer.Brand.Name}");
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n------------Menu------------");
            Console.WriteLine("1.Mostrar datos");
            Console.WriteLine("2.Agregar");
            Console.WriteLine("3.Editar");
            Console.WriteLine("4.Eliminar");
            Console.WriteLine("5.salir");
        }
    }
}