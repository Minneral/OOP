using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;

namespace LAB12;

static class TIVFileManager
{
    static StreamWriter sw;
    public static void GetFolderBody(string folderName)
    {
        Directory.CreateDirectory("TIVInspect");
        sw = new StreamWriter("TIVInspect\\tivdirinfo.txt");
        TIVLog.Log($"Попытка вывода файлов и папок папки {folderName}...");
        Console.WriteLine($"Попытка вывода файлов и папок {folderName}...");
        DirectoryInfo dir = new DirectoryInfo(folderName);
        try
        {
            WriteFolder(dir.FullName, 0);
        }
        catch
        {
            TIVLog.Log($"Папка {folderName} не найдена!");
            Console.WriteLine($"Папка {folderName} не найдена!");
            return;
        }
        sw.Close();
        Console.ForegroundColor = ConsoleColor.Gray;
        TIVLog.Log("Обход окончен!");
        Console.WriteLine("Обход окончен!");
    }

    static void WriteFolder(string path, int level)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        ConsoleColor color;

        StringBuilder spaceLevel = new StringBuilder();
        for (int i = 0; i < level; i++)
            spaceLevel.Append("  ");

        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (DirectoryInfo di2 in di.GetDirectories())
        {
            try
            {
                Console.WriteLine($"{spaceLevel.ToString()}+| {di2.Name}");
                sw.WriteLine($"{spaceLevel.ToString()}+| {di2.Name}");
                WriteFolder(di2.FullName, level + 1);
            }
            catch
            {
                color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{spaceLevel.ToString()}   ERROR: Отказано в доступе!");
                sw.WriteLine($"{spaceLevel.ToString()}   ERROR: Отказано в доступе!");
                Console.ForegroundColor = color;
            }
        }

        color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (FileInfo fi in di.GetFiles())
        {
            Console.WriteLine($"{spaceLevel.ToString()}-| {fi.Name}");
            sw.WriteLine($"{spaceLevel.ToString()}-| {fi.Name}");
        }
        Console.ForegroundColor = color;
    }
}