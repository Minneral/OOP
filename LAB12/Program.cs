using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

namespace LAB12;

public static class Program
{
    static void Initiaization()
    {
        if (Directory.Exists("archiveFiles")) Directory.Delete("archiveFiles", true);
        if (Directory.Exists("TIVFiles")) Directory.Delete("TIVFiles", true);
        if (Directory.Exists("TIVInspect")) Directory.Delete("TIVInspect", true);
        if (File.Exists("archive.zip")) File.Delete("archive.zip");
    }
    public static void Main()
    {
        Console.Write("Инициализация...");
        Initiaization();

        string localPath = "C:\\Users\\Еван\\OneDrive\\Рабочий стол\\C#\\LAB12";
        // DriveManager
        TIVDiskInfo.GetFreeSpace("C:\\");
        TIVDiskInfo.GetInfoAboutDisks();
        TIVDiskInfo.GetFileSystem("C:\\");


        //FileInfo
        TIVFileInfo.GetFullPath("tivlogfile.txt");
        TIVFileInfo.GetFileInfo("tivlogfile.txt");
        TIVFileInfo.GetCreatingTime("tivlogfile.txt");

        //DirectoryInfo
        TIVDirInfo.GetCountOfFiles(localPath);
        TIVDirInfo.GetCreateTime(localPath);
        TIVDirInfo.GetCountOfSubfolders(localPath);
        TIVDirInfo.GetRootFolder(localPath);

        //FileManager
        //-> a
        TIVFileManager.GetFolderBody("D:\\Files\\skins");
        Console.WriteLine();

        if (File.Exists("TIVInspect\\DriveInfo.txt"))
            File.Delete("TIVInspect\\DriveInfo.txt");

        File.Copy("TIVInspect\\tivdirinfo.txt", "TIVInspect\\DriveInfo.txt");
        TIVLog.Log("Скопирован файл", "из TIVInspect\\tivdirinfo.txt в TIVInspect\\DriveInfo.txt");
        Console.WriteLine("Скопирован файл из TIVInspect\\tivdirinfo.txt в TIVInspect\\DriveInfo.txt");
        Console.WriteLine();

        File.Delete("TIVInspect\\tivdirinfo.txt");
        TIVLog.Log("Удален файл TIVInspect\\tivdirinfo.txt");
        Console.WriteLine("Удален файл TIVInspect\\tivdirinfo.txt");
        Console.WriteLine();

        //-> b

        var di = Directory.CreateDirectory("TIVFiles");
        Console.WriteLine("Создан каталог: " + di.FullName);
        TIVLog.Log("Создан каталог ", di.FullName);
        Console.WriteLine();

        DirectoryInfo di2 = new DirectoryInfo("C:\\Users\\Еван\\OneDrive\\Рабочий стол\\Теория цвета");
        foreach (FileInfo a in di2.GetFiles())
            if (a.Extension == ".txt")
            {
                if (File.Exists("TIVFiles\\" + a.Name))
                    File.Delete("TIVFiles\\" + a.Name);
                File.Copy(a.FullName, "TIVFiles\\" + a.Name);
                TIVLog.Log("Скопирован файл", $"из {a.FullName} в TIVInspect\\{a.Name}");
                Console.WriteLine($"Скопирован файл из {a.FullName} в TIVInspect\\{a.Name}");
            }
        Console.WriteLine();

        Directory.Move("TIVFiles", "TIVInspect\\TIVFiles");
        Console.WriteLine("Перемещен каталог TIVFiles -> TIVInspect\\TIVFiles");
        TIVLog.Log("Перемещен каталог", "TIVFiles -> TIVInspect\\TIVFiles");
        Console.WriteLine();

        //-> c

        ZipFile.CreateFromDirectory("TIVInspect\\TIVFiles", "archive.zip");
        Console.WriteLine("Архивация файлов папки TIVInspect\\TIVFiles...");
        TIVLog.Log("Архивация файлов папки", "TIVInspect\\TIVFiles");
        Console.WriteLine();

        Directory.CreateDirectory("archiveFiles");
        Console.WriteLine("Создан каталог archiveFiles");
        TIVLog.Log("Создан каталог", "archiveFiles");
        Console.WriteLine();

        ZipFile.ExtractToDirectory("archive.zip", "archiveFiles");
        Console.WriteLine("Распаковка архива archive.zip в каталог archiveFiles...");
        TIVLog.Log("Распаковка архива", "archive.zip -> archiveFiles");
        Console.WriteLine();

        //Console.Clear();
        Console.WriteLine("Обработка лог-файла.\nЧтение файла...");
        StringBuilder log = new StringBuilder(File.ReadAllText("tivlogfile.txt"));

        Console.WriteLine("\nВывод отчета за 27.12.2022");

        log.Remove(0, log.ToString().IndexOf("НОВЫЙ ЗАПУСК: 27.12.2022"));
        int deleteEnd = log.ToString().IndexOf("НОВЫЙ ЗАПУСК");
        Console.WriteLine("Первая точка: " + deleteEnd);
        deleteEnd = log.ToString().IndexOf("НОВЫЙ ЗАПУСК", deleteEnd + 1);
        Console.WriteLine("Вторая точка: " + deleteEnd);
        Console.WriteLine("Длина строки: " + log.Length);
        log.Remove(deleteEnd, log.Length - deleteEnd);

        Console.WriteLine(log);

        Console.WriteLine("Вывод лога за последний час...");
        log = new StringBuilder(File.ReadAllText("tivlogfile.txt"));
        Console.WriteLine("Текущий час: " + DateTime.Now.TimeOfDay.Hours.ToString());

        // delete part
        string day, month, h;
        if (DateTime.Now.Day < 10)
            day = "0" + DateTime.Now.Day;
        else
            day = DateTime.Now.Day.ToString();
        if (DateTime.Now.Month < 10)
            month = "0" + DateTime.Now.Month;
        else
            month = DateTime.Now.Month.ToString();
        if (DateTime.Now.Hour < 10)
            h = "0" + DateTime.Now.Hour;
        else
            h = DateTime.Now.Hour.ToString();

        deleteEnd = log.ToString().IndexOf($"НОВЫЙ ЗАПУСК: {day}.{month}.{DateTime.Now.Date.Year} {h}");

        // НЕ ПЕРЕПИСЫВАЕМ САМ ФАЙЛ, ЧТОБЫ НЕ ТЕРЯТЬ ДАННЫЕ !
        Console.WriteLine("Символов для удаления: " + deleteEnd + ", полный размер: " + log.Length);
        log.Remove(0, deleteEnd - 1);
        Console.WriteLine(log);


    }
}