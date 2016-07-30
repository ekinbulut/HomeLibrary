using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Users
{
    public class UserRepository : EfRepositoryBase<EUser,int> , IUserRepository
    {
        public UserRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public EUser GetUserByName(string username)
        {
            return DbContext.Set<EUser>().FirstOrDefault(u => u.Userame.Equals(username));
        }
    }
}
