using System.Security.Cryptography.X509Certificates;

namespace LR2
{
    public static class Program
    {
        public static List<Owner> owners = new List<Owner>();
        public static List<Account> accounts = new List<Account>();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {         
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}