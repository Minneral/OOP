using System.Runtime.CompilerServices;

namespace KR2;

class Channel
{
    public event Action Notice;

    public void Publish()
    {
        Console.WriteLine("Канал публикует новость!");
        Notice?.Invoke();
    }
}

class Subscriber
{
    public void ReadPublush()
    {
        Console.WriteLine("Читаем новости...");
    }
}

class Program
{
    public static void Main()
    {
        Random rand = new Random();
        List<char> list = new List<char>();

        for(int i = 0; i < 20; i++)
        {
            list.Add(Convert.ToChar('a' + rand.Next(26)));
        }
        
        foreach(var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n");

        var seq = from item in list orderby item select item;
        list = new List<char>(seq);
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }


        Console.WriteLine("\n\nDistinict:");
        var seq2 = seq.Distinct();
        foreach(var item in seq2)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("Amount of 'b': " + seq2.Count((c) => c == 'b'));

        Console.WriteLine("\n\n");
        seq2 = seq2.Except(seq2.Skip(3).Take(seq2.Count() - 3 - 2));
        foreach (var item in seq2)
        {
            Console.Write(item + " ");
        }




        Channel channel = new Channel();
        Subscriber subscriber = new Subscriber();
        channel.Notice += () =>
        {
            subscriber.ReadPublush();
        };


        channel.Publish();




        List<string> str = new List<string>();

        str = str.FindAll((s) => s[s.Length - 1] == 'd' && s.Length == 5);

    }
}
