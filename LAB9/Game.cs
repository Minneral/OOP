using System.Collections;
namespace LAB9;

public class Game
{
    public string Name { get; set; }
    public string Price { get; set; }
    public string[] userId;
    bool isActive;
    public bool IsActive 
    { 
        get
        {
            return this.isActive;
        } 
    }
    public void Launch()
    {
        isActive = true;
        Console.WriteLine("You've launched game!");
    }
    public void Stop()
    {
        isActive=false;
        Console.WriteLine("Shutting down the game...");
    }
    public Game() : this(default(string), default(string)) { }
    public Game(string name, string price)
    {
        Name = name;
        Price = price;
        isActive = false;
    }

    public override string ToString()
    {
        return $"Name: {Name}\t|\tPrice: {Price}";
    }
}
