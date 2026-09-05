using System;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor1 = new Doctor("Juan", 35);

            Console.WriteLine(doctor1.GetInfo());
        }

        class People
        {
            private string _name;
            private int _age;

            public People(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string GetInfo()
            {
                return _name + " " + _age;
            }
        }

        class Doctor : People
        {
            public Doctor(string name, int age) : base(name, age)
            {

            }
            
        }
    }
}