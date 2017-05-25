using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Users
{
    public class UserRepository : EfRepositoryBase<EUser,int> , IUserRepository
    {


        public EUser GetUserByName(string username)
        {
            return DbContext.Set<EUser>().FirstOrDefault(u => u.UserName.Equals(username) && u.IsActive);
        }

        public EUser GetUserByNameAndPassword(string username, string password)
        {
            return DbContext.Set<EUser>().FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password) && u.IsActive);
        }

        public UserRepository(BaseContext dbContext) : base(dbContext)
        {
        }
    }
}
