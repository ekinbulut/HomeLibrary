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
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext,Configuration>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<LibraryContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EAuthorConfiguration());
            modelBuilder.Configurations.Add(new EBookConfiguration());
            modelBuilder.Configurations.Add(new EGenreConfiguration());
            modelBuilder.Configurations.Add(new EPublisherConfiguration());
            modelBuilder.Configurations.Add(new ERackConfiguration());
            modelBuilder.Configurations.Add(new ERoleConfiguration());
            modelBuilder.Configurations.Add(new ESeriesConfiguration());
            modelBuilder.Configurations.Add(new EShelfConfiguration());
            modelBuilder.Configurations.Add(new EUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
