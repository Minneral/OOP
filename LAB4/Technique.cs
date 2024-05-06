using System.Xml.Linq;

namespace LAB4;
public class Technique : Product, iTechnique
{
    public string Model { get; set; }
    public string SerialNumber { get; set; }

    public Technique(string type, string name, string price, string model, string serialNumber)
    : base(type, name, price)
    {
        Model = model;
        SerialNumber = serialNumber;
    }
    /*public override void Sold()
    {
        Console.WriteLine("U bought smth");
    }*/
    public virtual void TurnOn() { }
    public virtual void TurnOff() { }
    public override int GetHashCode()
    {
        return HashCode.Combine(Model);
    }
    public override bool Equals(object? obj)
    {
        return Equals(obj as Technique);
    }
    public bool Equals(Technique technique)
    {
        return base.Equals(technique) && technique!= null && technique.Model == Model;
    }
    public override string ToString()
    {
        return "Info - " + base.ToString() + $"\nModel: {Model} | Serial Number: {SerialNumber}";
    }

    public override void SayHi()
    {
        Console.WriteLine("Hi i'm technique");
    }
}
    