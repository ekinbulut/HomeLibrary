using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Users
{
    public interface IUserRepository : IRepository<EUser,int>
    {
        EUser GetUserByName(string username);
    }
}