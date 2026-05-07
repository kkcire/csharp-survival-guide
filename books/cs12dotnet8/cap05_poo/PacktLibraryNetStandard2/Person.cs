using System.Security.Cryptography.X509Certificates;

namespace Packt.Shared;

public class Person : object
{
    //Fields
    public string? Name;
    public DateTimeOffset Born;

    public WondersOfTheAncientWorld BucketList;

    public List<Person> Children = new();

    public const string Species = "Homo Sapiens";

    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    //Constructor
    public Person()
    {
        //Constructor pode definir valores default para campos
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }
    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }
    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }
    public string SayHello(string name)
    {
        return $"{Name} says 'Hello, {name}!'";
    }

    public string OptionalParameters(int count, string command = "Run!", double number = 0.0, bool active = true)
    {
        return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active
        );
    }

    public void PassingParameters(int w, in int x, ref int y, out int z)
    {
        z = 100;

        w++;
        //x++
        y++;
        z++;
        WriteLine($"In the method: w={w}, x={x}, y={y}, z={z}");
    }
}