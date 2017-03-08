using System.Data.Entity;
using System.IO;
using System.Reflection;
using Library.Data.Mappings;
using Library.Data.Migrations;
using SenseFramework.Data.EntityFramework.Context;

namespace Library.Data
{
    public class LibraryContext : BaseContext
    {
        public LibraryContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext,Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var tierConfiguration = ConfigurationManager.AppSettings["TypeConfigurationAssembly"];

            ////If there are more than one assembly it will separate them.
            var typeMappingDll = "Library.Data.dll";

            //foreach (string typeMappingDll in typeMappingDlls)
            //{
            var path = Path.Combine(AssemblyInstaller.AssemblyDirectory, typeMappingDll);

            //modelBuilder.Configurations.AddFromAssembly(Assembly.LoadFile(path));

            modelBuilder.Configurations.Add(new EAuthorConfiguration());
            modelBuilder.Configurations.Add(new EBookConfiguration());
            modelBuilder.Configurations.Add(new EGenreConfiguration());
            modelBuilder.Configurations.Add(new EPublisherConfiguration());
            modelBuilder.Configurations.Add(new ERackConfiguration());
            modelBuilder.Configurations.Add(new ERoleConfiguration());
            modelBuilder.Configurations.Add(new ESeriesConfiguration());
            modelBuilder.Configurations.Add(new EShelfConfiguration());
            modelBuilder.Configurations.Add(new EUserConfiguration());
            //}

            base.OnModelCreating(modelBuilder);
        }
    }
}
