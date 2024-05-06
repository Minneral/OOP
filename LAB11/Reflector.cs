using System.ComponentModel;
using System.Reflection;

namespace LAB11;

public static class Reflector
{
    public static string? AssemblyName(string name)
    {
        Type t = Type.GetType(name);

        if (t == null)
            return null;
        return t.Assembly.FullName;
    }

    public static bool HasConstructors(string name)
    {
        Type t = Type.GetType(name);

        if (t == null)
            return false;
        if (t.GetConstructors().Length != 0)
            return true;
        else
            return false;
    }

    public static IEnumerable<string> GetMethods(string name)
    {
        Type t = Type.GetType(name);
        if (t == null)
            return null;

        List<string> methods = new List<string>();
        foreach(var item in t.GetMethods())
        {
            methods.Add(item.Name);
        }
        return methods;
    }

    public static IEnumerable<string> GetInterfaces(string name)
    {
        Type t = Type.GetType(name);
        if (t == null)
            return null;

        List<string> methods = new List<string>();
        foreach (var item in t.GetInterfaces())
        {
            methods.Add(item.Name);
        }
        return methods;
    }

    public static void FindMethod(string ClassName, Type type)
    {
        Type t = Type.GetType(ClassName);
        if (t == null)
            return;
        foreach(var item in t.GetMethods().Where(n => !n.Name.StartsWith("get_") && !n.Name.StartsWith("set_")))
        {
            if (item.GetParameters().Length > 0)
            {
                foreach(var param in item.GetParameters())
                {
                    if (param.ParameterType == type)
                        Console.WriteLine(item.Name);
                }
            }
        }
    }

    public static void Invoke(string className, string method, object obj)
    {
        Type t = Type.GetType(className);
        if (t == null)
            return;

        var met = t.GetMethod(method);
        if (met == null)
            return;

        met.Invoke(obj, new object[] { Convert.ToInt32(File.ReadAllLines("info.txt").First()) });
        met.Invoke(obj, new object[] { new Random().Next(10) });
    }
}

public static class Reflector<T> where T : class
{
    public static T Create()
    {
        Type t = typeof(T);
        if (t == null)
            return null;

        return (T)t.GetConstructors().Where(n => n.GetParameters().Length == 0).First().Invoke(null);
    }
}
