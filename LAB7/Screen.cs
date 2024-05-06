using System.Xml.Linq;

namespace LAB7;
public class Screen : Technique
{
    public string Resolution { get; set; }
    public string DiagonalSize { get; set; }

    public Screen(string name, string price, string serialNumber, string model, string resolution, string diagonalSize)
        : base("Screen", name, price, model, serialNumber)
    {
        Resolution = resolution;
        DiagonalSize = diagonalSize;
    }

    public override void TurnOff()
    {
        Console.WriteLine("Display OFF");
    }
    public override void TurnOn()
    {
        Console.WriteLine("Display ON");
    }

    public string Print()
    {
        return $"Resolution: {Resolution} | Diagonal Size: {DiagonalSize}";
    }
    public override string ToString()
    {
        return base.ToString() + $"\nResolution: {Resolution} | Diagonal Size: {DiagonalSize}";
    }
}
