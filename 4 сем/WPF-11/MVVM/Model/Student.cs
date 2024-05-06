using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPF_11.Core;

namespace WPF_11.MVVM.Model;

public class Student : ObservableObject
{
    private string name;
    private string surname;
    private string patronymic;
    private string faculty;
    private int course;
    private int cardNumber;

    public string Name
    {
        get { return name; }
        set { name = value;
            OnPropertyChanged();
        }
    }
    public string Surname
    {
        get { return surname; }
        set { surname = value;
            OnPropertyChanged();
        }
    }
    public string Patronymic
    {
        get { return patronymic; }
        set { patronymic = value;
            OnPropertyChanged();
        }
    }
    public string Faculty
    {
        get { return faculty; }
        set { faculty = value;
            OnPropertyChanged();
        }
    }
    public int Course
    {
        get { return course; }
        set { course = value;
            OnPropertyChanged();
        }
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CardNumber
    {
        get { return cardNumber; }
        set
        {
            cardNumber = value;
            OnPropertyChanged();
        }
    }
    public string FullName
    {
        get
        {
            return this.ToString();
        }
    }


    public override string ToString()
    {
        return $"{Surname} {Name} {Patronymic}\t{cardNumber}";
    }

    public static int ParseCardNumber(string obj)
    {
        Match match = Regex.Match(obj, @"\d+");


        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        else
            return 0;
    }

    public Student()
    {
        Name = String.Empty;
        Surname = String.Empty;
        Patronymic = String.Empty;
        Faculty = String.Empty;
        Course = 0;
        cardNumber = 0;
    }
    public Student(string name, string surname, string patronymic, string faculty, int course, int cardNumber)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Faculty = faculty;
        Course = course;
        CardNumber = cardNumber;
    }
}
