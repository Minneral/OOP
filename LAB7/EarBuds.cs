namespace LAB7;

public class EarBuds : Technique
{
    public string BatteryCapacity {get;set;}
    public string SoundPower {get;set;}

    public EarBuds (string name, string price, string serialNumber, string model, string batteryCapacity, string soundPower)
        : base("EarBuds", name, price, model, serialNumber)
    {
        BatteryCapacity = batteryCapacity;
        SoundPower = soundPower;
    }

    public override string ToString()
    {
        return base.ToString() +  $"\nBattery capacity: {BatteryCapacity} | Sound Power: {SoundPower}";
    }

}
