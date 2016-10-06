using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Shelfs
{
    public class ShelfRepository : EfRepositoryBase<EShelf,int> , IShelfRepository
    {
        public ShelfRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public EShelf GetShelfByName(string name)
        {
            return DbContext.Set<EShelf>().FirstOrDefault(x => x.Name == name);
        }

        public EShelf GetShelfById(int Id)
        {
            return DbContext.Set<EShelf>().FirstOrDefault(x => x.Id == Id);
        }
    }
}
