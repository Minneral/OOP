using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    static class StatisticOperation 
    {
        public static str Sum(str s1, str s2) // Статический метод, то есть его можно вызывать не создавав экземпляра класса
        {
            return new str(s1.value + s2.value); // Возвращает соединенные строки
        }

        public static int CharCounter(str s1) // Также статический метод, возвращает длину строки
        {
            return s1.value.Length;
        }



        public static int WordsCounter(this string s1) // Метод расширения для класса string. Для них необходимо использовать конструкцию с ключевым словом this
        {                                              // (Взаимодействие с методом смотреть в классе Program)
            int amount = 0;                            // Метод возвращает колтчество слов в строке
            for(int i=0; i < s1.Length; ++i)
            {
                if(s1[i] == ' ')
                {
                    amount++;
                }

            }

            return amount + 1;
        }



        public static string AddSmile(this string s1, int position)
        {
            return new string(s1.Insert(position, ":)"));
        } // Также метод расширения для класса String. Вовзращает строку, с вставленным смайликом на введеной позиции
    }
}
