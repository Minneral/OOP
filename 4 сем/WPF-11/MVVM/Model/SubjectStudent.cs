using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_11.MVVM.Model;

public class SubjectStudent
{
    public int ID { get; set; }
    public int SubjectId { get; set; }
    public int StudentId { get; set; }

    public SubjectStudent()
    {
        SubjectId = 0;
        StudentId = 0;
    }
    public SubjectStudent(int subjectID, int studentId)
    {
        SubjectId = subjectID;
        StudentId = studentId;
    }
}
