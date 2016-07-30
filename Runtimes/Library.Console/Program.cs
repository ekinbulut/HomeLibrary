using System;
using System.Threading.Tasks;
using SenseFramework;

namespace Library.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            
            MainAsync(args).Start();
            System.Console.ReadKey();
        }

        private static Task MainAsync(string[] args)
        {

            return new Task(() =>
            {
                try
                {
                    var fm = new SenseFrameworkModule();
                    fm.TrackMessages += Fm_TrackMessages;

                    fm.StartUp();

                }
                catch (Exception err)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine(err.Message);
                    System.Console.ResetColor();
                }
            });

        }

        private static void Fm_TrackMessages(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
