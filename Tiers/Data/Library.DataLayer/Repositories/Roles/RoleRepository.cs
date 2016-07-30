using System.Data.Entity;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Roles
{
    public class RoleRepository : EfRepositoryBase<ERole,int> , IRoleRepository
    {
        public RoleRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
