using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Users.Repositories
{
    public interface IUserRepository : IRepository<EUser,int>
    {
        EUser GetUserByName(string username);

        EUser GetUserByNameAndPassword(string username, string password);
    }
}