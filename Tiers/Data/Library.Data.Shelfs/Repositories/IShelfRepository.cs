using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Shelfs.Repositories
{
    public interface IShelfRepository :IRepository<EShelf,int>
    {
        EShelf GetShelfByName(string name);

        EShelf GetShelfById(int Id);
    }
}