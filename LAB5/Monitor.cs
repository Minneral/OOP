using System.Xml.Linq;

namespace LAB5;

public class Monitor : Technique, IComparer<Monitor>
{
    public string Weight { get; set; }  
    public Screen Display { get; set; }
    public Monitor(Screen display, string name, string price, string serialNumber, string model, string weight)
        :base(eType.Monitor, name, price, model, serialNumber)
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

    public int Compare(Monitor? m1, Monitor? m2)
    {
        if(m1 == null || m2 == null)
        {
            Console.WriteLine("You cant comparise NULL element (Monitor)");
            return -1;
        }
        else
        {
            if(m1.Display.Equals(m2.Display))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    public int Compare(Screen? m1, Screen? m2)
    {
        if (m1 == null || m2 == null)
        {
            Console.WriteLine("You cant comparise NULL element (Screen)");
            return -1;
        }
        else
        {
            if (m1.Equals(m2))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

}