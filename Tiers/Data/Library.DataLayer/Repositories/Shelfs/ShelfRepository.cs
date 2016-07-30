using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Shelfs
{
    public class ShelfRepository : EfRepositoryBase<EShelf,int> , IShelfRepository
    {
        public ShelfRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
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
