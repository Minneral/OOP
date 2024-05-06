using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR2;

public class MyCollection<T>
{
    List<T> list = new List<T>();

    bool Add(T obj)
    {
        if (obj == null)
        {
            return false;
        }
        list.Add(obj);
        return true;
    }

    bool Find(T obj)
    {
        if (obj == null)
            return false;

        if (list.Contains(obj))
            return true;
        else
            return false;
    }
}


