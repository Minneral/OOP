using System;
using System.Collections.Generic;
using System.Text;


namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            str s1 = new str("Some s4tring");    // Создаем объекты класса из варианта
            str s2 = new str("Another string"); // Создаем объекты класса из варианта
            Console.WriteLine("str s1 = {0}; s1 - 4 = {1}", s1.value, s1.value = (s1 - 4).value);   // Использование перегрузки для оператора '-' (минус) { s1 - 4 }

            Console.WriteLine("str s1 = {0}; (> - вхождение подстроки) s1 > 'Some' = {1} ", s1.value, s1 > "Some"); // Использование перегрузки для оператора '>'(больше) { s1 > "some" }

            Console.WriteLine("str s1 = {0}; s1 == 'some' = {1} ", s1.value, s1 == "some"); // / Использование перегрузки для оператора '==' { s1 == "some" }

            Console.WriteLine("str s1 = {0}; s1 + ' line' = {1} ", s1.value, (s1 + " line").value); // / Использование перегрузки для оператора '+' { s1 + " line" }

            Console.WriteLine("str s1 = {0}; str s2 = {1}; StatisticOperation.Sum(s1, s2) = {2}", s1.value, s2.value, StatisticOperation.Sum(s1, s2).value); // Использование методов из
                                                                                                           // Статического класса StaticOperation: StatisticOperation.Sum(s1, s2).value)
            Console.WriteLine("str s1 = {0}; StatisticOperation.CharCounter(s1) = {1}", s1.value, StatisticOperation.CharCounter(s1)); // Аналогичное использование статического метода
                                                                                                                            

            string s3 = "hello";
                
            Console.WriteLine("string s3 = {0}, s3.WordsCounter() = {1}", s3, s3.WordsCounter()); // Использование методов расширения, сделанных для класса string: s3.WordsCounter()
                                                                                                  // Где s3 - объект типа string
            Console.WriteLine("string s3 = {0}, s3.AddSmile(2) = {1}", s3, s3.AddSmile(2));        

        }
    }
}
