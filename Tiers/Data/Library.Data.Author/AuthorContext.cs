using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Author.Mappings;

namespace Library.Data.Author
{
    public class AuthorContext : BaseContext , IAuthorContext
    {
        protected AuthorContext():base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AuthorContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EAuthorConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
