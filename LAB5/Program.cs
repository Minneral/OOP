namespace LAB5;

class Program
{
    static void Main()
    {
        Screen Oled = new Screen("Oled", "70", "321-452", "JK-47L90", "4k", "21.5'");

        Monitor LG = new Monitor(Oled, "Osiris", "200", "ET-90403", "LG-K0432", "2.1 kg");

        PC Lenovo = new PC("Gerbert", "1200", "L-8231", "942-231", "Intel i9-11900k", "128 GB", "4 TB", "B450", "300W");

        Projector Proj = new Projector("myProjector", "100", "proj-9MLTP", "195-234", "500 NIT", "8 bit");

        EarBuds Xiaomi = new EarBuds("Xiaomi earbuds", "30", "988-888", "mi-4", "2000mAh", "2.2 ddb");

        Table table = new Table("Stinger", "oak", "0,5", "1", "Rectangle");

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

        Product[] computers = new Product[]
        {
            Lenovo,
            new PC("ASUS", "1000", "L-8331", "912-231", "Intel i9-8900k", "128 GB", "4 TB", "B450", "500W"),
            new PC("MSI", "1500", "K-3231", "942-531", "Intel i7-11900k", "256 GB", "4 TB", "B450", "800W"),
            new PC("HP", "900", "L-3231", "142-231", "Intel i5-8700k", "64 GB", "2 TB", "B450", "400W")
        };

        MyContainer container = new MyContainer();

        Console.WriteLine(table.ToString() + "\n\n");

        for(int i =0; i < computers.Length; i++)
        {
            container.AddElement(computers[i]);
        }

        //container.AddElement(Oled);
        //container.AddElement(LG);
        //container.AddElement(Lenovo);

        container.Print();
        Console.Write("\n\nSorted print:\n");
        container.SortPrint();

        container.FindUnsuitableElement(container);

        Console.WriteLine($"\nTotal price of all technique: {container.GetTotalPrice(container)}");


        container.InitFromFile("product.txt");
        Console.WriteLine("\n\n\nInit from file:\n");
        container.Print();
    }
}