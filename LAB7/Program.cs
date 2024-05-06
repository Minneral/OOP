using Microsoft.VisualBasic;

namespace LAB7;

class Program
{
    public static void Main()
    {
        try
        {
            CollectionType<Product> collection = new CollectionType<Product>();
            Product PC1 = new PC("Asus", "200", "PREDATOR", "987231", "intel core I7-11700k", "2TB", "32GB", "Z470", "800W");
            Product NullRef = null;
            collection.Add(PC1);

            collection.Show();

            collection.Add(NullRef);

            CollectionType2<int> collection2 = new CollectionType2<int>();
            collection2.Add(45);
            collection2.Add(21);
            collection2.WriteToFile("file.txt");
            collection2.Show();


            CollectionType2<string> collection3 = new CollectionType2<string>();
            collection3.Add("Hello");
            collection3.Show();

            CollectionType2<float> collection4 = new CollectionType2<float>();
            collection4.Show();
            collection4.Add(1.2f);
            collection4.Show();



            CollectionType2<int> collection5 = new CollectionType2<int>();
            collection5.InitFromFile("file.txt");
            collection5.Show();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}