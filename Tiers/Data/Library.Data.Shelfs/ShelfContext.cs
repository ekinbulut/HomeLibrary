using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Shelfs.Mappings;

namespace Library.Data.Shelfs
{
    public class ShelfContext : BaseContext , IShelfContext
    {
        public ShelfContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShelfContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new EShelfConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
