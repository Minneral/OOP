using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KR;

public class Date
{
    //  -> (1) В нашем классе должны быть поля day, month, year
    public string Day // Автоматическое свойство на чтение и запись
    {
        get; set;
    }
    public string Month // Автоматическое свойство на чтение и запись
    {
        get; set;
    }
    public string Year // Автоматическое свойсвто только на чтение
    {
        get;
    }

    public override int GetHashCode() // Переопределение метода GetHashCode() для дальнейшего его использования в методе Equals
    {
        return HashCode.Combine(Day + Month + Year);  // HashCode.Combine() возвращает контрольную сумму от введенного аргумента, то есть от (day + month + year)
    }
    public override bool Equals(object? obj) // Переопределение метода Equals для сравнения наших объектов класса Date
    {
        return GetHashCode() == obj.GetHashCode(); // Проверяем, совпадает ли контрольная сумма элементов
    }

    public Date(string day, string month, string year) // Конструктор с параметрами
    {
        this.Day = day;      // Ключевое слово this. возвращает ссылку на текущий объект
        this.Year = year;
        this.Month = month;
    }
    
    public Date() : this("", "", "") { } // Пустой конструктор, при вызове которого, тот запускает другой конструктор (Определенный у нас чуть выше) со следующей сигнатурой (stirng, string, string)

    public static string operator %(Date d, int n) // Перегрузка оператора '%' для нашего класса. Обязательно должен присутствовать параметр с типом текущего класса, в нашем случае (Date d)
    {
        try      // Конструкция try - catch нужна для отлова исключений
        {
            switch (n) // В зависимости от n выполняем следующие строки кода:
            {

                case 1:
                    return d.Day;  // Если n равен 1, то возвращаем значение поля day
                case 2:
                    return d.Month; // Если n равен 2, то возвращаем значение поля month
                default:
                    throw new Exception("Other case"); // Во всех остальных случаях генерируем новое исключение, используя конструкцию "throw new Exception()", с текстом "Other case"

            }
        }
        catch(Exception e)  // Обрабатываем исключения, если такие будут во время выполнения программы
        {
            Console.WriteLine($"Error: {e.Message}");  // Если сгенерировалось исключение, то выводим следующий текст в консоль
            return null;                    
        }
       
    }
}
