namespace Library.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LibraryServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.LibraryServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // LibraryServiceProcessInstaller
            // 
            this.LibraryServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LibraryServiceProcessInstaller.Password = null;
            this.LibraryServiceProcessInstaller.Username = null;
            // 
            // LibraryServiceInstaller
            // 
            this.LibraryServiceInstaller.Description = "LibraryOS WCF Host Service";
            this.LibraryServiceInstaller.ServiceName = "LibraryService";
            this.LibraryServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LibraryServiceInstaller,
            this.LibraryServiceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LibraryServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller LibraryServiceInstaller;
    }
}