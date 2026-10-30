

using System.Threading.Channels;
using System.Xml.Serialization;

Operation mySum = Functions.Sum;
//parte del paradigma funcional, es poder asignar fuinciones a variables
//y luego pasarlas como parametros a otras funciones
//Console.WriteLine(mySum(5,3));

mySum = Functions.Mul;
//Console.WriteLine(mySum(5,3));

Show show = Console.WriteLine;
show += Functions.ConsoleShow;
//show("Hola Mundo");

//Functions.Some("Matias", "Meza", show);

#region Action
Action<string> showMessage = Console.WriteLine;
showMessage("Hola");
Functions.SomeAction("Matias", "Meza", showMessage);
#endregion

#region Delegados
delegate int Operation(int a, int b);
public delegate void Show(string message);

#endregion
public class Functions
{
    public static int Sum(int x, int y)
    {
        return x + y;
    }
    public static int Mul(int num1, int num2)
    {
        return num1 * num2;
    }
    public static void ConsoleShow(string m) => Console.WriteLine(m.ToUpper());
    public static void Some(string name, string lastName, Show fn)
    {
        Console.WriteLine("Hago algo al inicio");
        fn($"Hola {name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }

    public static void SomeAction(string name, string lastName, Action<string> fn)
    {
        Console.WriteLine("Hago algo al inicio");
        fn($"Hola {name} {lastName}");
        Console.WriteLine("Hago algo al final");
    }
}

