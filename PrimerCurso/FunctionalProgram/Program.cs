

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
//expresiones labda una funcion anonima que solo existe en este contexto
Action<string, string> showMessage2 = (a, b) => { Console.WriteLine($"{a} + {b}"); };
//showMessage2("Matias", "Meza");
Action<string, string, string> showMessage3 = (a, b, c) => { Console.WriteLine($"{a} {b} {c}"); };
//showMessage3("Matias", "Meza", "Junior Dev");
//Functions.SomeAction("Matias", "Meza", (a) => {
//    Console.WriteLine("Soy una expresion Lambda " + a);
//});
//Functions.SomeAction("Matias", "Meza", showMessage);
#endregion

#region Func

Func<int> numberRandom = () => new Random().Next(0,100);
Func<int, int> numberRandomLimit = (limit) => new Random().Next(0, limit);
//Console.WriteLine(numberRandom());
//Console.WriteLine(numberRandomLimit(76));
#endregion

#region Predicate
Predicate<string> hasSpaceOrA = (word) => word.Contains(" ") || word.ToUpper().Contains("A");
Console.WriteLine(hasSpaceOrA("Hola Mundo"));
Console.WriteLine(hasSpaceOrA("Matias"));

var words = new List<string>()
{
    "beer", "patito", "sandia", "Hola Mundo", "c#"
};
Console.WriteLine("------FinAll-------");
var wordsNew = words.FindAll(hasSpaceOrA);
foreach(var a in wordsNew)
{
    Console.WriteLine(a);
}
Console.WriteLine("------Negacion-------");
//negando
var wordsNew2 = words.FindAll((w)=>!hasSpaceOrA(w));
foreach (var a in wordsNew2)
{
    Console.WriteLine(a);
}
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

