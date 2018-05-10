using Library.Data.Author.Mappings;
using Library.Data.Books.Mappings;
using Library.Data.Genres.Mappings;
using Library.Data.Publishers.Mappings;
using Library.Data.Racks.Mappings;
using Library.Data.Roles.Mappings;
using Library.Data.Series.Mappings;
using Library.Data.Shelfs.Mappings;
using Library.Data.Users.Mappings;
using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;

namespace Library.Data
{
    public class LibraryContext : BaseContext
    {
        public LibraryContext()
        {
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
