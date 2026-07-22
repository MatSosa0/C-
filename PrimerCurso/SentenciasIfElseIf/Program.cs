using System;

namespace SentenciasIfElseIf
{
    class Program 
    {
        static void Main(string[] args)
        {
            bool areYouHungry = true;
            bool youHaveMoney = true;

            if (areYouHungry && youHaveMoney && IsOpenRestaurant("Lonches juan",11))
            {
                Console.WriteLine("Come");
            }
            else
            {
                Console.WriteLine("No Comas");
            }
        }

        static bool IsOpenRestaurant(string name, int hour = 0)
        {
            if(name == "Lonches pepe" && hour > 8 && hour < 23)
            {
                return true;
            }
            else if(name == "Restaurant 24 Horas")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}