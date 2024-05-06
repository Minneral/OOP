delegate void del(int a);

class Program
{
    public void Foo(int a)
    {
        Console.WriteLine("DKK");
    }
    static void Main()
    {
        del a;
        del b = new del(new Program().Foo);
        a = b;
        b(5);
    }
}