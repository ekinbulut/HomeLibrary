using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using SenseFramework;

namespace Library.Service
{
    public partial class LibraryService : ServiceBase
    {
        public LibraryService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var task = new Task(() =>
            {
                var fm = new SenseFrameworkModule();
                fm.StartUp();

            });

            task.Start();

            //new Task(Start).Start();
        }

        protected override void OnStop()
        {
        }

        public void Start()
        {
            var thread = new Thread(StartHostingServices);
            thread.Start();
        }

        private void StartHostingServices()
        {
            var sensefm = new SenseFrameworkModule();

            sensefm.StartUp();

        }
    }
}
