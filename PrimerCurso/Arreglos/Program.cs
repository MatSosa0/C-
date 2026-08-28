using System;

namespace Arreglos
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables que puede colecciones
            string[] friends = new string[7] {
            "Pancho",
            "Paco",
            "Ana",
            "Ruben",
            "Karla",
            "Luis",
             null
            };

            friends[0] = "Hector";
            // se agrego el for para no repetir el console.Writeline por cada elemento del arreglo
            for (int i = 1; i <= (friends.Length - 1); i++)
            {
                Console.WriteLine(friends[i]);
            }

            Console.WriteLine("Se agrega un nuevo amigo");

            friends[6] = "Carlos";

            for (int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine(friends[i]);
            }

            int count = 0;
            do
            {
                Console.WriteLine(friends[count]);
                count++;
            } while (count < friends.Length);
        }
    }
}