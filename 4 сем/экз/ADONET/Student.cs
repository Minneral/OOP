using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET;

public class Student
{
    public string FIO { get; set; }
    public int Course { get; set; }

    public Student()
    {
        FIO = String.Empty;
        Course = default(int);
    }

    public Student(string fio, int course)
    {
        FIO = fio;
        Course = course;
    }
}
