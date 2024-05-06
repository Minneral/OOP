using System.Text;

namespace LAB11;

public class Program
{
    static string name = "LAB11.myClass";
    public static void Main()
    {
        Console.WriteLine("Interfaces:");
        foreach(var item in Reflector.GetInterfaces(name))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nMethods:");
        foreach (var item in Reflector.GetMethods(name))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nAssembly Name:\n" + Reflector.AssemblyName(name));

        Console.WriteLine("\nHas constructors: " + Reflector.HasConstructors(name).ToString());

        Console.WriteLine("\nMethods with int-param:\n");
        Reflector.FindMethod(name, typeof(int));

        Console.WriteLine("\nInvoke method Foo():");
        Reflector.Invoke(name, "Foo", new myClass());


        myClass a = Reflector<myClass>.Create();
    }
}

public class myClass : IComparable<myClass>
{
    public string Name { get; set; }
    public int a;

    public void Foo(int a) { Console.WriteLine(a); }
    public void Boo(float a) { }

    public int CompareTo(myClass obj)
    {
        return 8;
    }

    public myClass(string name)
    {
        Name = name;
    }
    public myClass() : this("") { }
}