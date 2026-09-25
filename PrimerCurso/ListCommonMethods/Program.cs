using System;
using System.Collections.Generic;

namespace ListCommonMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                4,3,5,19
            };

            Show(numbers);
            numbers.Insert(1,6); //se especifica el indice
            Show(numbers);

            if (numbers.Contains(19))
            {
                Console.WriteLine("Existe");
            }
            else
            {
                Console.WriteLine("No existe");
            }

            int pos = numbers.IndexOf(19);
            Console.WriteLine(pos);
            pos = numbers.IndexOf(100);
            Console.WriteLine(pos);

            //sort
            numbers.Sort();
            Show(numbers);

            // Add range
            numbers.AddRange(new List<int>()
            {
                300,200,100
            });
            Show(numbers);
        }

        public static void Show(List<int> numbers)
        {
            Console.WriteLine("--Numeros--");

            foreach( var n in numbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}