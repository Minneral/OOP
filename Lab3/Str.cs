using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class str // Класс, даденый по заданию
    {
        public string value; // Поле с данными
        public class Developer // Вложенный класс Developer
        {
            public string fio;
            public string id;
            public string department;

            public Developer() : this("", "", "") { } // Пустой конструктор, который вызывает другой конструктор с сигнатурой (string, string, string)
            public Developer(string fio, string id, string department)
            {
                this.fio = fio;
                this.id = id;
                this.department = department;
            }
        }

        Production prod = new Production("18537", "Company"); // Вложенный объект класса Production
        Developer dev = new Developer("Name", "Id", "dep");
        public str() : this("") { } // Пустой конструктор, который вызывает другой конструктор с сигнатурой (string)
        public str(string s) // Конструктор с параметром
        {
            this.value = s; // this. возвращает ссылку на текущий элемент, то есть на экземпляр класса str
        }
        public static str operator -(str s1, int x) // Перегрузка оператора ' - ' (Минус). В качестве параметров обязательно на первом месте должен быть объект класса, 
        {                                           // для которого перегружается оператор. В моем случае: str s1.
            if (s1.value.Contains(x.ToString()))
            {
                return new str { value = s1.value.Replace(x.ToString(), "") };
            }
            else
            {
                return new str { value = s1.value };
            }
        }
        public static str operator +(str s1, int x) // Ниже идут перегрузки для других операторов
        {
            return new str { value = s1.value + x };
        }
        public static str operator +(str s1, string x)
        {
            return new str { value = s1.value + x };
        }
        public static bool operator >(str s1, string s2)
        {
            if (s1.value.Contains(s2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(str s1, string s2)
        {
            if (s2.Contains(s1.value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(str s1, string s2)
        {
            if (string.Compare(s1.value, s2) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator ==(str s1, string s2)
        {
            if (string.Compare(s1.value, s2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
