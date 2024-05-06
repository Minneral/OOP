namespace LAB7;

public class Projector : Technique
{
    public string Power { get; set; }
    public string ColorReproduction { get; set; }

    public Projector(string name, string price, string model, string serialNumber, string power, string colorReproduction)
        : base("Projector", name, price, model, serialNumber)
    {
        Power = power;
        ColorReproduction = colorReproduction;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nPower: {Power} | Color reproduction: {ColorReproduction}";
    }
}
