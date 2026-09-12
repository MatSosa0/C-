using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Shark[] sharks = new Shark[] 
            { 
                new Shark("Espada", 45),
                new Shark("Jaws", 65)
            };

            IFish[] fish = new IFish[]
            {
                new Siren (100)
            };

            ShowFish(sharks);

            ShowAnimals(sharks);
        }

        public static void ShowAnimals(IAnimal[] animals)
        {
            Console.WriteLine("-- Mostramos animales");
            int i = 0;
            while( i < animals.Length)
            {
                Console.WriteLine(animals[i].Name);
                i++;
            }
        }
        public static void ShowFish(IFish[] fishs)
        {
            Console.WriteLine("-- Mostramos los peces --");

            int i = 0;

            while(i < fishs.Length)
            {
                Console.WriteLine(fishs[i].Swim());
                i++;
            }
        }
    }

    public class Siren : IFish
    {
        public int Speed { get; set; }
        public Siren(int Speed)
        {
            this.Speed = Speed;
        }
        public string Swim()
        {
            return $"La Sirena nada a {Speed} km/h";
        }
    }

    public class Shark: IAnimal, IFish
    {
        public Shark(string Name, int Speed)
        {
            this.Name = Name;
            this.Speed = Speed;
        }
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Swim()
        {
            return $"{Name} nada a la velocidad {Speed} km/h";
        }
    }
    public interface IAnimal
    {
        public string Name { get; set; }
    }

    public interface IFish
    {
        public int Speed { get; set; }
        public string Swim();
    }
}