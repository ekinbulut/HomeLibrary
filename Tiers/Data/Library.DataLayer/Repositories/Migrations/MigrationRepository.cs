using System.Data.Entity;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Migrations
{
    public class MigrationRepository : EfRepositoryBase<EMigration, int>, IMigrationRepository
    {
        public MigrationRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
