using System;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RconSharp;

namespace SomeShit;

class Pogram
{
    public static void Main()
    {
        string command = "";
        string result = "";
        string host = "";
        Task<bool> isAuthenticated = default(Task<bool>);
        string password = "";
        int port = 0;
        bool isConnected = false;
        RconClient rcon = default(RconClient);

        do
        {
            Console.Write("IP-Адрес сервера: ");
            host = Console.ReadLine();
            Console.Write("RCON-PORT: ");
            if (int.TryParse(Console.ReadLine(), out int res))
            {
                port = res;
            }
            else
            {
                Console.WriteLine("Порт должен быть целым числом!");
                continue;
            }
 
            rcon = RconClient.Create(host, port);

            if(rcon.ConnectAsync().IsFaulted == false)
            {
                while (true)
                {
                    Console.Write("Введите пароль: ");
                    password = Console.ReadLine();
         
                    if (rcon.AuthenticateAsync(password).Result == true)
                    {
                        isConnected = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный пароль!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Не удалось установить соединение!");
            }
        } while (isConnected == false);


        Console.WriteLine("Соединение успешно установлено!");
        while(true)
        {
            Console.Write("> ");
            command = Console.ReadLine();
            result = rcon.ExecuteCommandAsync(command).Result;
            Console.WriteLine("- " + result);
        }
    }
}