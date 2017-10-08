using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Series.Mappings;

namespace Library.Data.Series
{
    public class SeriesContext : BaseContext , ISeriesContext
    {
        public SeriesContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SeriesContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ESeriesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
