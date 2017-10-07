using Library.Data.Racks.Mappings;
using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;

namespace Library.Data.Racks
{
    public class RackContext : BaseContext, IRackContext
    {
        public RackContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RackContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ERackConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
