using Library.Data.Athentication.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Athentication.Repositories.Users
{
    public interface IUserRepository : IRepository<EUser,int>
    {
        EUser GetUserByName(string username);
    }
}