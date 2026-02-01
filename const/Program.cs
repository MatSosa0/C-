// See https://aka.ms/new-console-template for more information
using System;

namespace ConstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string configuration = "This config will never change";
            Console.WriteLine(configuration);
        }
    }
}

