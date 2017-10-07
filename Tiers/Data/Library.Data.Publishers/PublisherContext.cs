using Library.Data.Publishers.Mappings;
using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;

namespace Library.Data.Publishers
{
    public class PublisherContext : BaseContext , IPublisherContext
    {

        public PublisherContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PublisherContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EPublisherConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
