using System.Reflection;

namespace LAB10;
class Program
{
    public static void Main()
    {
        string[] monthes = new string[] { "June", "July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May" };
        IEnumerable<string> take1 = monthes.Where(n => n.Length == 4);
        foreach(var item in take1)
        {
            Console.WriteLine(item);
        }
        IEnumerable<string> take2 = monthes.Where(n => n == "June" || n == "July" || n == "August");
        IEnumerable<string> take3 = monthes.Where(n => n == "December" || n == "January" || n == "February");
        IEnumerable<string> take4 = monthes.OrderBy(n => n);
        IEnumerable<string> take5 = monthes.Where(n => n.Length >= 5).Where(n => n.Contains('u'));
        foreach (var item in take5)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n----------------\n");

        List<Triangle> tri = new List<Triangle>();
        tri.Add(new Triangle());
        tri.Add(new Triangle(new Point(-1, 0), new Point(0, 3), new Point(4, 0)));
        tri.Add(new Triangle(new Point(-4, 0), new Point(0, 3), new Point(1, 5)));
        tri.Add(new Triangle(new Point(0, 0), new Point(0, 7), new Point(4, 0)));
        tri.Add(new Triangle(new Point(6, 4), new Point(1, 3), new Point(12, 0)));
        tri.Add(new Triangle(new Point(1, 1), new Point(3, 3), new Point(5, 6)));
        tri.Add(new Triangle(new Point(7, 0), new Point(1, 2), new Point(6, 3)));
        tri.Add(new Triangle(new Point(2, 1), new Point(10, 3), new Point(14, 5)));
        tri.Add(new Triangle(new Point(3, 1), new Point(4, 1), new Point(9, 2)));

        var maxPerimeter = tri.Max(n => n.GetPerimeter());
        var minPerimeter = tri.Min(n => n.GetPerimeter());

        var maxArea = tri.Max(n => n.GetArea());
        var minArea = tri.Min(n => n.GetArea());

        //var amount = tri.GroupBy(n => n.DefineType()).Select(n => new { key = n.Key, count = n.Count() });
        var amount = tri.GroupBy(n => n.DefineType()).Select(t => new
        {
            key = t.Key,
            count = t.Count(),
            minPer = t.Min(j => j.GetPerimeter()),
            maxPer = t.Max(j => j.GetPerimeter()),
            minArea = t.Min(j => j.GetArea()),
            maxArea = t.Max(j => j.GetArea())
        });

        Console.WriteLine("\n");
        foreach (var item in amount)
        {
            Console.Write(item.key + ": ");
            Console.WriteLine(item.count);
            Console.WriteLine("Min/Max Perimeter: " + item.minPer + " / " + item.maxPer);
            Console.WriteLine("Min/Max Area: " + item.minArea + " / " + item.maxArea);
            Console.WriteLine();
        }


        Console.WriteLine("Triangle with min area:");
        float minTrValue = tri.Min(t => t.GetArea());
        var minTr = tri.FirstOrDefault(t => t.GetArea() == minTrValue);
        minTr.Print();
        Console.WriteLine("Area: " + minTrValue);

        Console.WriteLine("\n----------------\n");
        Console.WriteLine("\nTriangles whiches sides length belongs to range: 1 - 6");
        var triFromRange = tri.Where(t => t.BelongToRange(1, 6));
        foreach(var item in triFromRange)
        {
            item.ShowInfo();
            Console.WriteLine("\n~~~~~~\n");
        }


        var triOrderedArray = tri.OrderBy(t => t.GetPerimeter()).ToArray();




        // task4

        var multi = monthes.Take(monthes.Length / 2).Where(t => t.Contains('u')).Select(t => t.ToCharArray()).Max(t => t.Length);
        Console.WriteLine(multi);


        // task 5

        List<Game> games = new List<Game>()
            {
                new Game { Name = "Prime World", Developer ="Nival" },
                new Game { Name = "WarCraft", Developer ="Blizzard Entertainment" }
            };
        List<Player> players = new List<Player>()
            {
                new Player {Name="Виталя", Game="Prime World"},
                new Player {Name="Лера", Game="WarCraft"},
                new Player {Name="Валера", Game="Prime World"}
            };

        var result = from pl in players
                     join g in games on pl.Game equals g.Name
                     select new { Name = pl.Name, Game = pl.Game, Developer = g.Developer };

        foreach (var info in result)
        {
            Console.WriteLine($"{info.Name} - {info.Game} ({info.Developer})");
        }

    }

    class Player
    {
        public string Name { get; set; }
        public string Game { get; set; }
    }
    class Game
    {
        public string Name { get; set; }
        public string Developer { get; set; }
    }

}
