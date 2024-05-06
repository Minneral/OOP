namespace LAB4;

public interface iTechnique
{
    string Type { get; set; }
    string Name { get; set; }
    string Price { get; set; }
    string Model { get; set; }
    void TurnOn();
    void TurnOff();
    void SayHi();
}
