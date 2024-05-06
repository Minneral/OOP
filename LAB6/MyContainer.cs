using System.ComponentModel;

namespace LAB5;

public class MyContainer : MyController, ICloneable
{
    List<Product> data = new List<Product>();
    public bool IsEmpty()
    {
        if(data.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Count()
    {
        return data.Count();
    }
    public Product this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            this.SetElement(value, index);
        }
    }
    public Product GetElement(int index)
    {
        try
        {
            if (data.Count > index)
            {
                return data[index];
            }
            else
            {
                throw new Exception("Not correct index to get an Element!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            return null;
        }
    }
    public void SetElement(Product o, int index)
    {
        try
        {
            if (data.Count > index)
            {
                data[index] = o;
            }
            else
            {
                throw new Exception("Not correct index to set an Element!");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    public void Print()
    {
        if (data.Count() != 0)
        {
            foreach (var item in data)
            {
                if (item is Product)
                {
                    Console.WriteLine(item.ToString() + "\n");
                }
            }
        }
    }
    public void SortPrint()
    {
        List<Product> buffer = new List<Product>();

        foreach(var item in data)
        {
            buffer.Add(item);
        }

        try
        {
            if (buffer.Count() != 0)
            {
                for (int i = 0; i < buffer.Count(); i++)
                {
                    for (int j = 0; j < buffer.Count() - 1; j++)
                    {
                        if (int.Parse(buffer[j].Price) < int.Parse(buffer[i].Price))
                        {
                            object temp = buffer[i];
                            buffer[i] = buffer[j];
                            buffer[j] = temp as Product;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("No elements to sort");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}\n");
        }

        
        foreach (var item in buffer)
        {
            if (item is Product)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
    }
    public object Clone()
    {
        return new List<Product>(data);
    }
    public void AddElement(Product o)
    {
        try
        {
            if (o != null)
                data.Add(o);
            else
                throw new Exception("You can't add NULL value into Container!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    public void DelElement(int index)
    {
        try
        {
            if (data.Count > index)
            {
                data.RemoveAt(index);
            }
            else
            {
                throw new Exception("Not correct index to delete an Element!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
    public void InitFromFile(string path)
    {
        data.Clear();

        using (StreamReader stream = new StreamReader(path))
        {
            while (stream.ReadLine() is string line)
            {
                switch (line)
                {
                    case "#Monitor":
                        AddElement(new Monitor(new Screen(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()),
                            stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()));
                        break;

                    case "#PC":
                        AddElement(new PC(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(),
                            stream.ReadLine(), stream.ReadLine()));
                        break;

                    case "#Screen":
                        AddElement(new Screen(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()));
                        break;

                    case "#Projector":
                        AddElement(new Projector(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()));
                        break;

                    case "#EarBuds":
                        AddElement(new EarBuds(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()));
                        break;

                    case "#Table":
                        AddElement(new Table(stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine(), stream.ReadLine()));
                        break;
                }
            }
            stream.Close();
        }
    }

}
