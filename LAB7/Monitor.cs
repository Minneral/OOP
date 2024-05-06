using System.Xml.Linq;

namespace LAB7;

public class Monitor : Technique
{
    public string Weight { get; set; }  
    public Screen Display { get; set; }
    public Monitor(Screen display, string name, string price, string serialNumber, string model, string weight)
        :base("Monitor", name, price, model, serialNumber)
    {
        this.Weight = weight;
        this.Display = display;
    }

    public override void TurnOff()
    {
        Console.WriteLine("Monitor OFF");
    }
    public override void TurnOn()
    {
        Console.WriteLine("Monitor ON");
    }
    public override string ToString()
    {
        return base.ToString() + $"\nDisplay: {Display.Print()}\nWeight: {Weight}";
    }

}