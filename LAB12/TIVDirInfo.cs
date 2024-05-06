using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LAB12;

public static class TIVDirInfo
{
    public static void GetCountOfFiles(string path)
    {
        TIVLog.Log($"Получение количества файлов...", path);
        Console.WriteLine($"Получение количества файлов... | {path}");
        if (Directory.Exists(path))
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TIVLog.Log($"Файлов в каталоге: {di.GetFiles().Length}");
            Console.WriteLine($"Файлов в каталоге: {di.GetFiles().Length}");
        }
        {
            TIVLog.Log("Каталог не найден!");
            Console.WriteLine("Каталог не найден!");
        }
    }

    public static void GetCreateTime(string path)
    {
        TIVLog.Log("Получение даты создания каталога...", path);
        Console.WriteLine($"Получение даты создания каталога... | {path}");
        if (Directory.Exists(path))
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TIVLog.Log($"Дата создания: {di.CreationTime}");
            Console.WriteLine($"Дата создания: {di.CreationTime}");
        }
        else
        {
            TIVLog.Log($"Каталог не найден!");
            Console.WriteLine($"Каталог не найден!");
        }
    }

    public static void GetCountOfSubfolders(string path)
    {
        TIVLog.Log($"Получение количества подкаталогов...", path);
        Console.WriteLine($"Получение количества подкаталогов... | {path}");
        if (Directory.Exists(path))
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TIVLog.Log($"Подкаталогов: {di.GetDirectories().Length}");
            Console.WriteLine($"Подкаталогов: {di.GetDirectories().Length}");
        }
        else
        {
            TIVLog.Log("Каталог не найден!");
            Console.WriteLine("Каталог не найден!");
        }
    }

    public static void GetRootFolder(string path)
    {
        TIVLog.Log($"Получение пути...", path);
        Console.WriteLine($"Получение пути... | {path}");
        if (Directory.Exists(path))
        {
            DirectoryInfo di = new DirectoryInfo(path);
            TIVLog.Log($"Родительский каталог: {di.Parent.FullName}");
            Console.WriteLine($"Родительский каталог: {di.Parent.FullName}");
        }
        else
        {
            TIVLog.Log("Каталог не найден!");
            Console.WriteLine("Каталог не найден!");
        }
    }
}
