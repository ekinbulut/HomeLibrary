using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Genres
{
    public class GenreRepository : EfRepositoryBase<EGenre,int> , IGenreRepository
    {
        public GenreRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public EGenre GetGenreByName(string name)
        {
            return DbContext.Set<EGenre>().FirstOrDefault(x => x.Genre == name);
        }
    }
}
