using Interface;
using Reflexia;
using System.Reflection;

internal class Program
{
    public static string pathToPeopleDet = @"D:\repos\Reflexia\Reflexia\PeopleDetector\bin\Debug\net8.0\PeopleDetector.dll";
    private static void Main(string[] args)
    {
        
        ReflectionManager reflectionManager = new ReflectionManager();
        var dets = reflectionManager.GetAllDetector();
        foreach (var det in dets) { Console.WriteLine(det.Process()); }

        Console.WriteLine("Hello, World!");
    }
}