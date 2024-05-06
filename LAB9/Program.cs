using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LAB9;

public class Program
{
    public static void Main()
    {
        //Task1
        GameCollection game = new GameCollection();

        game.Add(new Game("Fortnite", "0"));
        game.Add(new Game("cs:go", "100"));

        foreach(var item in game)
        {
            Console.WriteLine(item.ToString());
        }

        game.Delete("cs:go");
        foreach (var item in game)
        {
            Console.WriteLine(item.ToString());
        }

        Game el;

        el = game.Find(a => a.Name == "Fortnite");
        Console.WriteLine("\nToString:\n" + el.ToString());



        //Task2
        Random rand = new Random();
        BlockingCollection<int> blockingCollection = new BlockingCollection<int>();
        for(int i = 0; i < 10; i++)
        {
            blockingCollection.Add(rand.Next(100));
        }

        foreach(var item in blockingCollection)
        {
            Console.WriteLine(item.ToString());
        }

        for(int i = 0; i < 4; i++)
            blockingCollection.Take();
        Console.WriteLine("\n");
        foreach (var item in blockingCollection)
        {
            Console.WriteLine(item.ToString());
        }


        Console.WriteLine("\nAdding new values:");
        blockingCollection.Add(999);
        blockingCollection.TryAdd(998);

        foreach (var item in blockingCollection)
        {
            Console.WriteLine(item.ToString());
        }

        Queue<int> queue = new Queue<int>(blockingCollection);
        Console.WriteLine("\nQueue:");
        
        foreach(var item in queue)
        {
            Console.WriteLine(item.ToString());
        }


        //Finding value
        if(queue.Contains(999))
            Console.WriteLine("Queue contains: 999");



        //Task 3

        void DoSomeThingWhenChanges(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Game newGame)
                        Console.WriteLine($"Добавлен новый объект: {newGame.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Game oldGame)
                        Console.WriteLine($"Удален объект: {oldGame.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    if ((e.NewItems?[0] is Game replacingGame) &&
                        (e.OldItems?[0] is Game replacedGame))
                        Console.WriteLine($"Объект {replacedGame.Name} заменен объектом {replacingGame.Name}");
                    break;
            }
        }
        ObservableCollection<Game> observableCollection = new ObservableCollection<Game>();

        observableCollection.CollectionChanged += DoSomeThingWhenChanges;

        Game rust = new Game("Rust", "20");
        Game forest = new Game("The Forest", "10");

        observableCollection.Add(rust);
        observableCollection.Add(forest);

        observableCollection.Remove(rust);

    }
}