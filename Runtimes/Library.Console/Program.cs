using System;
using System.Threading.Tasks;
using SenseFramework;
using Topshelf;

namespace Library.Console
{
    static class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceEntry>();

                x.SetServiceName("Library.Host.Controller");
                x.SetDisplayName("Library Host Controller");

                x.UseLog4Net("log4net.config");


            });
        }


    }

}
