namespace LAB5;

partial class MyController
{
    public void FindUnsuitableElement(MyContainer container)
    {
        Screen screen = new Screen("Oled", "70", "321-452", "JK-47L90", "4k", "21.5'");

        Monitor monitor = new Monitor(screen, "", "", "", "", "");

        Console.WriteLine("UnSuitable elements are:\n");

        for (int i = 0; i < container.Count(); ++i)
        {
            Product item = container.GetElement(i);
            if (item.Type == Product.eType.PC)
            {
                string power = ((PC)item).PowerUnit;
                if( int.TryParse(power.Trim('w', 'W'), out int iPower))
                {
                    if(iPower <= 300)
                    {
                        Printer.IAmPrinting((iTechnique)item);
                    }
                }
            }
        }
    }
}
