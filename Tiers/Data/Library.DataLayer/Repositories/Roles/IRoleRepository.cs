using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Athentication.Repositories.Roles
{
    public interface IRoleRepository : IRepository<ERole,int>
    {
    }
}