using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Genres.Mappings;

namespace Library.Data.Genres
{
    public class GenreContext : BaseContext , IGenreContext
    {
        public GenreContext()
        {


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EGenreConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
