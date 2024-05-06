using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB7;

public interface iAction<T>
{
    void Add(T obj);
    void Remove(T obj);
    void Show();
}
