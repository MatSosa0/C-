using System;

namespace Variables
{
    class Progam
    { 
        static void Main(string[] args)
        {
            int number = 1;
            int number2 = 2;

            Console.WriteLine(number);
            Console.WriteLine(number2);

            number = 3;

            Console.WriteLine(number);

            int number3 = number + number2;

            Console.WriteLine(number3);
        }
    }
}
