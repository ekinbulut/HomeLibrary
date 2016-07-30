using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Genres
{
    public class GenreRepository : EfRepositoryBase<EGenre,int> , IGenreRepository
    {
        public GenreRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public EGenre GetGenreByName(string name)
        {
            return DbContext.Set<EGenre>().FirstOrDefault(x => x.Genre == name);
        }
    }
}
