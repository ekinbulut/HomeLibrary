using System.ServiceProcess;
using System.Threading;

namespace Library.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if !DEBUG
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LibraryService()
            };
            ServiceBase.Run(ServicesToRun);
#else
            var svc = new LibraryService();
            svc.Start();

            Thread.Sleep(Timeout.Infinite);

#endif

        }
    }
}
