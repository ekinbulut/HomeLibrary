using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Books.Mappings;

namespace Library.Data.Books
{
    public class BookContext : BaseContext , IBookContext
    {
        protected BookContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EBookConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
