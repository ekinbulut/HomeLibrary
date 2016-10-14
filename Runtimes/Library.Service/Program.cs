using System.ServiceProcess;

namespace Library.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LibraryService()
            };
            ServiceBase.Run(ServicesToRun);

            //var svc = new LibraryService();
            //svc.Start();
        }
    }
}
