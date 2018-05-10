using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Shelfs.Repositories
{
    public class ShelfRepository : EfRepositoryBase<EShelf,int> , IShelfRepository
    {
        public ShelfRepository(BaseContext dbContext) : base(dbContext)
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
