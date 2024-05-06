using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Binding;

public class User
{
    public string Name { get; set; }
    public int Course { get; set; }

    public User()
    {
        Name = string.Empty;
        Course = default(int);
    }
    public User(string name, int course)
    {
        Name = name;
        Course = course;
    }

    public override string ToString()
    {
        return Name;
    }
}
