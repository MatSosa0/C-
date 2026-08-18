using System;

namespace While
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            while ( i < 10)
            {
                Console.WriteLine("Iteracion de i :" + i);
                i++;
            }

            int j = 0;

            while ( j < 100)
            {
                if (j > 10)
                {
                    break;
                }
                Console.WriteLine("Iteracion de j :" + j);
                j++;
            }
        }
    }
}