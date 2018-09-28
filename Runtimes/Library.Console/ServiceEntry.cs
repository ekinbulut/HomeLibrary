using SenseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Library.Console
{
    public class ServiceEntry : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            MainAsync(null).Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }


        private Task MainAsync(string[] args)
        {

            return new Task(() =>
            {
                try
                {
                    var fm = new SenseFrameworkModule();
                    fm.TrackMessages += Fm_TrackMessages;

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

        private void Fm_TrackMessages(string message)
        {
            System.Console.WriteLine(message);
        }
    }

}
