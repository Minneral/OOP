using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB12;

public static class TIVFileInfo
{
    public static void GetFullPath(string fileName)
    {
        TIVLog.Log("Получение полного пути к файлу...", fileName);
        Console.WriteLine($"Получение полного пути к файлу... | {fileName}");
        if (File.Exists(fileName))
        {
            FileInfo fi = new FileInfo(fileName);
            TIVLog.Log($"Путь: {fi.FullName}");
            Console.WriteLine($"Путь: {fi.FullName}");
        }
        else
        {
            TIVLog.Log($"Файл не найден!");
            Console.WriteLine($"Файл не найден!");
        }
    }

    public static void GetFileInfo(string fileName)
    {
        TIVLog.Log("Получение информации о файле.", fileName);
        Console.WriteLine($"Получение информации о файле... | {fileName}");
        if (File.Exists(fileName))
        {
            FileInfo fi = new FileInfo(fileName);
            TIVLog.Log($"Имя: {fi.Name}, расширение: {fi.Extension}, размер: {fi.Length} байт");
            Console.WriteLine($"Имя: {fi.Name}, расширение: {fi.Extension}, размер: {fi.Length} байт");
        }
        else
        {
            TIVLog.Log($"Файл не найден!");
            Console.WriteLine($"Файл не найден!");
        }
    }

    public static void GetCreatingTime(string fileName)
    {
        TIVLog.Log("Получение даты создания файла...", fileName);
        Console.WriteLine($"Получение даты создания файла... | {fileName}");
        if (File.Exists(fileName))
        {
            FileInfo fi = new FileInfo(fileName);
            TIVLog.Log($"Дата создания: {fi.CreationTime}");
            Console.WriteLine($"Дата создания: {fi.CreationTime}");
        }
        else
        {
            TIVLog.Log($"Файл не найден!");
            Console.WriteLine($"Файл не найден!");
        }
    }
}
