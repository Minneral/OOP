using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KR;
// -> (2) Создаем класс

public class BelDate : Date, IGood, IBad // Наш новый класс должен наследовать методы и поля класса Date, а также реализовывать два интерфейса, их также создаем в отдельных файлах
{
    string status; // Закрытое поле класса
    void IGood.Plus() // Пишем реализацию метода Plus() для интерфейса IGood. То есть у нас происходит обращение: IGood.Plus()
    {
        Console.WriteLine("I am good");
    }
    void IBad.Plus() // Пишем реализацию метода Plus() для интерфейса IBad. То есть у нас происходит обращение: IBad.Plus()
    {
        Console.WriteLine("I am bad");
    }

    public BelDate() : base("", "", "") { }  // Пустой конструктор, который вызывает базовый конструктор (тавтология). То есть вызывается конструктор класса Date с сигнатурой (string, string, string)
    public BelDate(string day, string month, string year) : base(day, month, year) { } // Аналогичный конструктор, только с параметрами :)

    public void Status(string s)  // Свойство для поля status
    {
        status = s;
    }
}
