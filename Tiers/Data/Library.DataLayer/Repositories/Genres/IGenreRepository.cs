using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Genres
{
    public interface IGenreRepository  : IRepository<EGenre,int>
    {
        EGenre GetGenreByName(string name);
    }
}