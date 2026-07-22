using System;

namespace Funciones
{
    class Program 
    {
        static void Main(string[] args)
        {
            Show();
            Sum(3, 5);
            Sum(2, 3);
            int m = Mul(2, 3);

            Console.WriteLine(m);
        }

        static void Sum(int num1, int num2)
        {
            int calculo = num1 + num2;
            Console.WriteLine("Suma: " + calculo);
        }
        static void Show()
        {
            Console.WriteLine("Hola soy un texto que se imprime desde funcion");
        }

        static int Mul(int num1, int num2)
        {
             int calculo = num1 * num2;
            return calculo;
        }
    }
}