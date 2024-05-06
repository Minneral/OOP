namespace LAB5;

public partial class MyController
{
    public int GetTotalPrice(MyContainer container)
    {
        int total = 0;

        for (int i = 0; i < container.Count(); ++i)
        {
            total += int.Parse(container.GetElement(i).Price);
        }

        return total;
    }

}

