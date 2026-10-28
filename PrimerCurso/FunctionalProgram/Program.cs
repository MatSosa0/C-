
Operation mySum = Functions.Sum;
//parte del paradigma funcional, es poder asignar fuinciones a variables
//y luego pasarlas como parametros a otras funciones
Console.WriteLine(mySum(5,3));

mySum = Functions.Mul;
Console.WriteLine(mySum(5,3));

Show show = Functions.ConsoleShow;
show("Hola Mundo");

delegate int Operation(int a, int b);
delegate void Show(string message);

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
    public static void ConsoleShow(string m) => Console.WriteLine(m);
}

