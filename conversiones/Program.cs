using System;

// namespace ConversionesApp
// {
//     class Progam{
//         static void Main(string[] args)
//         {
//             int num = 1000;
//             byte secondNumber = (byte)num;
//             Console.WriteLine(secondNumber);
//         }
//     }
// }

// namespace ConversionesApp
// {
//     class Progam{
//         static void Main(string[] args)
//         {
//             string textNumber = "1234";
//             int num = Int32.Parse(textNumber); // puede ser solo int.Parse
//             Console.WriteLine(num);

//             try
//             {
//                 string invalidTextNumber = "1234.7";
//                 int invalidNumber = Int32.Parse(invalidTextNumber);
//                 Console.WriteLine(invalidNumber);
//             }
//             catch (Exception)
//             {
//                 Console.WriteLine("Something went wrong");
//             }
//         }
//     }
// }


namespace ConversionesApp
{
    class Progam{
        static void Main(string[] args)
        {
            string textNumber = "Mark";
            int number;
            bool ok = int.TryParse(textNumber, out number);
            Console.WriteLine(ok);
            Console.WriteLine(number);

        }
    }
}