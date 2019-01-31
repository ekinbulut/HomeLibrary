using SenseFramework;
using System;
using System.Threading.Tasks;
using Topshelf;

namespace Library.Console
{
    public class ServiceEntry : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            MainAsync().Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }


        private Task MainAsync()
        {

            return new Task(() =>
            {
                try
                {
                    var fm = new SenseFrameworkModule();

                    fm.StartUp();

                    System.Console.WriteLine($"Press any key to exit...");

                }
                catch (Exception err)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine(err.Message);
                    System.Console.ResetColor();
                }
            });

        }
    }

}
