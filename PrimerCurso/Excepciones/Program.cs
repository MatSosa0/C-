using System;
using System.IO;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText(@"C:\Users\Windows 11\Documents\pato.txt");
                Console.WriteLine(content);

                string content2 = File.ReadAllText(@"C:\Users\Windows 11\Documents\pato2.txt");
                Console.WriteLine(content2);

                throw new Exception("Ocurrio algo raro");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("El archivo no existe");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Se ejecuta siempre");
            }

            Console.WriteLine("aqui se sigue ejecutando");
        }
    }
}