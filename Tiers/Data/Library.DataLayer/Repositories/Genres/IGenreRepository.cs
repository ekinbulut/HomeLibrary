using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Genres
{
    public interface IGenreRepository  : IRepository<EGenre,int>
    {
        EGenre GetGenreByName(string name);
    }
}