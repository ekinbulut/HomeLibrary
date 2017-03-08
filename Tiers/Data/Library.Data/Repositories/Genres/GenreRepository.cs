using System;
using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Genres
{
    public class GenreRepository : EfRepositoryBase<EGenre,int> , IGenreRepository
    {
        public GenreRepository(BaseContext dbContext) : base(dbContext)
        {
        }

        public EGenre GetGenreByName(string name)
        {
            return DbContext.Set<EGenre>().FirstOrDefault(x => x.Genre == name);
        }

        public EGenre CreateGenreIfNotExists(string name)
        {
            return DbContext.Set<EGenre>().FirstOrDefault(x => x.Genre == name) ?? CreateEntity(new EGenre {Genre = name,CreatedDateTime = DateTime.Now});

        }
    }
}
