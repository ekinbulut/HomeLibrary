using System.Data.Entity;
using Castle.Core.Logging;
using Library.Data.Athentication.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Athentication.Repositories.Roles
{
    public class RoleRepository : EfRepositoryBase<ERole,int> , IRoleRepository
    {
        public RoleRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
