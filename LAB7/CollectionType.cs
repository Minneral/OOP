using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB7;

public class CollectionType<T> : iAction<T> where T : Product
{
    List<T> list;

    public void Add(T obj)
    {
        try
        {
            if (obj == null)
            {
                throw new NullReferenceException("Нельзя добавить null-элемент");
            }
            list.Add(obj);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Remove(T obj)
    {
        try
        {
            if (obj == null)
            {
                throw new NullReferenceException("Нельзя удалить null-элемент");
            }
            list.Remove(obj);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Show()
    {
        try
        {
            if (list.Count <= 0)
            {
                throw new ArgumentException("Коллекция пуста!");
            }
            list.ForEach(Console.WriteLine);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public CollectionType()
    {
        list= new List<T>();
    }
}

public class CollectionType2<T> : iAction<T>
{
    List<T> list;

    public void Add(T obj)
    {
        try
        {
            if (obj == null)
            {
                throw new NullReferenceException("Нельзя добавить null-элемент");
            }
            list.Add(obj);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Remove(T obj)
    {
        try
        {
            if (obj == null)
            {
                throw new NullReferenceException("Нельзя удалить null-элемент!");
            }
            list.Remove(obj);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Show()
    {
        try
        {
            if (list.Count <= 0)
            {
                throw new ArgumentException("Коллекция пуста!");
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InitFromFile(string path)
    {
        using(StreamReader sr = new StreamReader(path))
        {
            while(sr.ReadLine() is string line)
            {
                list.Add((T)Convert.ChangeType(line, typeof(T)));
            }
            sr.Close();
        }
    }

    public void WriteToFile(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            for(int i =0; i < list.Count; i++)
            {
                sw.WriteLine(list[i].ToString());
            }
        }
    }

    public CollectionType2()
    {
        list = new List<T>();
    }
}
