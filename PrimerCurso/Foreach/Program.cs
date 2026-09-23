using System;
using System.Collections.Generic;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>
            {
                1,2,34,5,67,78
            };

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}