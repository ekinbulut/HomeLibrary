using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Authors
{
    public interface IAuthorRepository : IRepository<EAuthor,int>
    {
        EAuthor GetAuthorByName(string name);
    }
}