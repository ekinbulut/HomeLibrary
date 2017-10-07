using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Genres.Repositories
{
    public interface IGenreRepository  : IRepository<EGenre,int>
    {
        EGenre GetGenreByName(string name);
        EGenre CreateGenreIfNotExists(string name);
    }
}