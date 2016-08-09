using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
            new Task(Start).Start();
        }

        protected override void OnStop()
        {
        }

        public void Start()
        {
            var task = new Task(StartHostingServices, TaskCreationOptions.LongRunning);
            task.Start();
        }

        private void StartHostingServices()
        {
            var sensefm = new SenseFramework.SenseFrameworkModule();

            sensefm.StartUp();

        }
    }
}
