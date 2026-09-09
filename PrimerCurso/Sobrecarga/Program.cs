using System;

namespace Sobrecarga
{
    class Program
    {
        static void Main(string[] args)
        {
            Math math = new Math();

            Console.WriteLine(math.Sum(5,7));
            Console.WriteLine(math.Sum("6","8"));

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine(math.Sum(numbers));
        }
    }

    class Math
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        
        public int Sum(string a, string b)
        {
            return int.Parse(a) + int.Parse(b);
        }

        public int Sum(int[] numbers)
        {
            int resultado = 0;
            for (int i= 0; i< numbers.Length; i++)
            {
                resultado += numbers[i];
            }
            return resultado;
        }
    }

}