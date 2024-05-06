using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB12;

static class TIVDiskInfo
{
    public static void GetFreeSpace(string diskName)
    {
        TIVLog.Log($"Попытка узнать свободное место на диске: {diskName}");
        Console.WriteLine($"Попытка узнать свободное место на диске: {diskName}");
        DriveInfo di = new DriveInfo(diskName);
        try
        {
            TIVLog.Log($"Свободно: {di.TotalFreeSpace / (1024 * 1024)} МБ");
            Console.WriteLine($"Свободно: {di.TotalFreeSpace / (1024 * 1024)} МБ");
        }
        catch
        {
            TIVLog.Log($"Диск {diskName} не найден!");
            Console.WriteLine($"Диск {diskName} не найден!");
        }
    }

    public static void GetFileSystem(string diskName)
    {
        TIVLog.Log($"Попытка узнать файловую систему диска: {diskName}");
        Console.WriteLine($"Попытка узнать файловую систему диска: {diskName}");
        DriveInfo di = new DriveInfo(diskName);
        try
        {
            TIVLog.Log($"ФС установлена: {di.DriveFormat}");
            Console.WriteLine($"ФС установлена: {di.DriveFormat}");
        }
        catch
        {
            TIVLog.Log("Не удалось распознать ФС!");
            Console.WriteLine("Не удалось распознать ФС!");
        }
    }

    public static void GetInfoAboutDisks()
    {
        TIVLog.Log($"Получаем информацию о дисках...");
        Console.WriteLine($"Получаем информацию о дисках...");
        foreach (DriveInfo di in DriveInfo.GetDrives())
        {
            TIVLog.Log($"Имя: {di.Name}, объем: {di.TotalSize}, доступно: {di.TotalFreeSpace}, метка: {di.VolumeLabel}");
            Console.WriteLine($"Имя: {di.Name}, объем: {di.TotalSize}, доступно: {di.TotalFreeSpace}, метка: {di.VolumeLabel}");
        }
    }
}