using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Racks
{
    public class RackRepository : EfRepositoryBase<ERack,int> , IRackRepository
    {
        public RackRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ERack GetRackByRackNumber(int number)
        {
            return DbContext.Set<ERack>().FirstOrDefault(x => x.RackNumber == number);
        }
    }
}
