using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            numbers.Add(5);
            numbers.Add(2);

            Console.WriteLine(numbers.Count);

            List<int> numbers2 = new List<int>()
            {
                1,2,3,4,5,10,14
            };

            Console.WriteLine(numbers2.Count);
        }
    }
}