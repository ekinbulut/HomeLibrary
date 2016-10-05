using System.Data.Entity;
using Library.Data.Athentication.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Athentication.Repositories.Roles
{
    public class RoleRepository : EfRepositoryBase<ERole,int> , IRoleRepository
    {
        public RoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
