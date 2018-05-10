using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Racks.Repositories
{
    public class RackRepository : EfRepositoryBase<ERack,int> , IRackRepository
    {
        public RackRepository(BaseContext dbContext) : base(dbContext)
        {
        }

        public ERack GetRackByRackNumber(int number)
        {
            return DbContext.Set<ERack>().FirstOrDefault(x => x.RackNumber == number);
        }
    }
}
