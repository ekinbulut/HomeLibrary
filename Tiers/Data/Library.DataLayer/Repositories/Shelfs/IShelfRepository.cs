using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Shelfs
{
    public interface IShelfRepository :IRepository<EShelf,int>
    {
        EShelf GetShelfByName(string name);

        EShelf GetShelfById(int Id);
    }
}