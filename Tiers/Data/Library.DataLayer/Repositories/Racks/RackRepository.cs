using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Racks
{
    public class RackRepository : EfRepositoryBase<ERack,int> , IRackRepository
    {
        public RackRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public ERack GetRackByRackNumber(int number)
        {
            return DbContext.Set<ERack>().FirstOrDefault(x => x.RackNumber == number);
        }
    }
}
