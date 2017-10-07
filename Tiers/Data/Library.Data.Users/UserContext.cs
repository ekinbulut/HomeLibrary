using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Users.Mappings;

namespace Library.Data.Users
{
    public class UserContext : BaseContext , IUserContext
    {
        public UserContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<UserContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
