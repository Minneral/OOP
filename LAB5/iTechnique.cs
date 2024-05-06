namespace LAB5;

public interface iTechnique
{
    Product.eType Type { get; set; }
    string Name { get; set; }
    string Price { get; set; }
    string Model { get; set; }
    void TurnOn();
    void TurnOff();
}
