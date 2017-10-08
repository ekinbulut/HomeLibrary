using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Roles.Repositories
{
    public interface IRoleRepository : IRepository<ERole,int>
    {
    }
}