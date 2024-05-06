using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR2;

[Serializable]
public class Owner
{
    public FIO _FIO { get; set; }
    public DateTime BirthDay { get; set; } 
    public PASSPORT Passport { get; set; }

    public Owner()
    {
        this._FIO = new FIO();
        this.BirthDay = new DateTime(1, 1, 1);
        this.Passport = new PASSPORT();
    }
    public Owner(FIO fio, DateTime birthDay, PASSPORT passport)
    {
        this._FIO = fio;
        this.BirthDay = birthDay;
        this.Passport = passport;
    }

}

[Serializable]
public struct FIO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    public override string ToString()
    {
        return Surname + " " + Name + " " + Patronymic;
    }

    public FIO()
    {
        this.Name = "unknown";
        this.Surname = "unknown";
        this.Patronymic = "unknown";
    }

    public FIO(string name = "unknown", string surname = "unknown", string patronymic = "unknown")
    {
        this.Name = name;
        this.Surname = surname;
        this.Patronymic = patronymic;
    }
}
[Serializable]
public struct PASSPORT
{
    public string Series { get; set; }
    public int Number { get; set; }

    public PASSPORT()
    {
        this.Series = "unknown";
        this.Number = 0;
    }

    public override string ToString()
    {
        return $"{Series}{Number}";
    }
    public PASSPORT(string series = "unknown", int number = 0)
    {
        this.Series = series;
        this.Number = number;
    }
}