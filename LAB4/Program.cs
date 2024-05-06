namespace LAB4;

class Program
{
    static void Main()
    {
        Screen Oled = new Screen("Oled", "70 usd", "321-452", "JK-47L90", "4k", "21.5'");

        Monitor LG = new Monitor(Oled, "Osiris", "200 usd", "ET-90403", "LG-K0432", "2.1 kg");

        PC Lenovo = new PC("Gerbert", "1200 usd", "L-8231", "942-231", "Intel i9-11900k", "128 GB", "4 TB", "B450", "800W");

        Projector Proj = new Projector("myProjector", "100 usd", "proj-9MLTP", "195-234", "500 NIT", "8 bit");

        EarBuds Xiaomi = new EarBuds("Xiaomi earbuds", "30 usd", "988-888", "mi-4", "2000mAh", "2.2 ddb");

        Table table = new Table("Stinger", "54 usd", "0.5 meters", "1 meter", "Rectangle");

        Product[] products = new Product[]
        {
            table,
            Oled,
            LG,
            Lenovo,
            Proj,
            Xiaomi,
        };

        iTechnique[] iTech = new iTechnique[]
        {
            Oled,
            LG,
            Lenovo,
            Proj,
            Xiaomi,
        };

        /* for(int i = 0; i < products.Length; i++)
         {
             Console.WriteLine(products[i].Name + ":\n" + products[i].ToString() + "\n");
         }*/


        for (int i = 0; i < iTech.Length; i++)
        {
            Printer.IAmPrinting(iTech[i]);
            Console.WriteLine();
        }

        if(LG is Technique)
        {
            Console.WriteLine("I'm tech");
        }


        Console.WriteLine("\n\nMethods with the same names");
        ((Product)Oled).SayHi();
        ((iTechnique)Oled).SayHi();

        Console.WriteLine("\n");

        ((Product)table).SayHi();
    }
}