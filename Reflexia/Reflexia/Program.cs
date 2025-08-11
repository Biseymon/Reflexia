using System.Reflection;
using Interface;

internal class Program
{
    public static string pathToPeopleDet = @"D:\repos\Reflexia\Reflexia\PeopleDetector\bin\Release\net8.0\publish\win-x86\PeopleDetector.dll";
    private static void Main(string[] args)
    {
        
        Assembly assembly = Assembly.LoadFrom(pathToPeopleDet);
        Console.WriteLine("Assembly is null? " + (assembly == null).ToString());
        Type? type = assembly.GetType("PeopleDetector");
        Console.WriteLine("Type is null? " + (type is null).ToString());
        if (type != null) 
        {
            object peopleDetector = Activator.CreateInstance(type);
            IDetector iDet = (IDetector)peopleDetector;
            /*object convertObj = Convert.ChangeType(peopleDetector, typeof(IDetector));
            IDetector iDet = (IDetector)convertObj;*/
            Console.WriteLine(iDet.Process());
        }



        Console.WriteLine("Hello, World!");
    }
}