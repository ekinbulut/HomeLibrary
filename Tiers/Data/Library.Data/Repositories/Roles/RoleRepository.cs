using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Roles
{
    public class RoleRepository : EfRepositoryBase<ERole,int> , IRoleRepository
    {
        public RoleRepository(BaseContext dbContext) : base(dbContext)
        {
        }
    }
}
