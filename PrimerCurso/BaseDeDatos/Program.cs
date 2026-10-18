using Microsoft.VisualBasic.FileIO;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace BaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BeerDB db = new BeerDB(@"DESKTOP-NJB8MT2\SQLEXPRESS", "csharpDB", "admin", "123");
                bool again = true;
                int op = 0;
                do
                {
                    ShowMenu();
                    Console.WriteLine("Elige una opcion");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Show(db);
                            break;
                        case 2:
                            AddBeer(db);
                            break;
                        case 3:
                            Edit(db);
                            break;
                        case 4:
                            Delete(db);
                            break;
                        case 5:
                            again = false;
                            break;

                    }

                } while (again);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("No pudimos conectarnos");
            }
        }
        public static void AddBeer(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva Cerveza");
            Console.WriteLine("Escribe el nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine("Escribe el ID de la marca: ");
            int BrandId = int.Parse(Console.ReadLine());
            Beer beer = new Beer(name,BrandId);
            beerDB.AddBeer(beer);
        }
        public static void ShowMenu()
        {
            Console.WriteLine("\n-------------Menu---------------");
            Console.WriteLine("1. Mostrar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
        }

        public static void Show( BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Cervezas de la base de datos");
            List<Beer> beers = beerDB.GetBeers();

            foreach (var b in beers)
            {
                Console.WriteLine($"Id: {b.Id}, Nombre: {b.Name}, Marca: {b.BrandId}");
            }
        }

        public static void Edit(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);
            Console.WriteLine("Editar Cerveza");

            Console.WriteLine("Escribe el ID de la cerveza a editar: ");
            int id = int.Parse(Console.ReadLine());

            Beer beer = beerDB.Get(id);

            if(beer != null)
            {
                Console.WriteLine("Escribe el nombre: ");
                string name = Console.ReadLine();
                Console.WriteLine("Escribe el ID de la Marcar");
                int brandID = int.Parse(Console.ReadLine());

                beer.Name = name;
                beer.BrandId = brandID;
                beerDB.EditBeer(beer);
            }
            else
            {
                Console.WriteLine("Cerveza no encontrada");
            }
        }

        public static void Delete(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escribe el ID de la cerveza a eliminar:");
            int id = int.Parse(Console.ReadLine());

            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                beerDB.DeleteBeer(id);
            }
            else
            {
                Console.WriteLine("La cerveza no fue encontrada");
            }


        }
    }
}