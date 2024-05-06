using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LAB12;

public static class TIVLog
{
    public static void Log(string action, string? path = null)
    {
        if (path != null)
            File.AppendAllText("tivlogfile.txt", $"{DateTime.Now}: {action} | {path}\n");
        else
            File.AppendAllText("tivlogfile.txt", $"{DateTime.Now}: {action}\n");
    }

    static TIVLog() { File.AppendAllText("tivlogfile.txt", $"\n\nНОВЫЙ ЗАПУСК: {DateTime.Now}\n"); }
}
