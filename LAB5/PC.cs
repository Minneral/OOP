namespace LAB5;

public class PC : Technique
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string ROM { get; set; } 
    public string MotherBoard { get; set; }
    public string PowerUnit { get; set; }

    public PC(string name, string price, string model, string serialNumber, string cPU, string rAM, string rOM, string motherBoard, string powerUnit)
        : base(eType.PC, name, price, model, serialNumber)
    {
        CPU = cPU;
        RAM = rAM;
        ROM = rOM;
        MotherBoard = motherBoard;
        PowerUnit = powerUnit;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCPU: {CPU} | RAM: {RAM} | ROM: {ROM} | Motherboard: {MotherBoard} | Power unit: {PowerUnit}";
    }
}
