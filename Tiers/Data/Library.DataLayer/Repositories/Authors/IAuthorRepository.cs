using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Authors
{
    public interface IAuthorRepository : IRepository<EAuthor,int>
    {
        EAuthor GetAuthorByName(string name);
    }
}