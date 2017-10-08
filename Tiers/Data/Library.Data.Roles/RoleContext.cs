using SenseFramework.Data.EntityFramework.Context;
using System.Data.Entity;
using Library.Data.Roles.Mappings;

namespace Library.Data.Roles
{
    public class RoleContext : BaseContext , IRoleContext
    {

        public RoleContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<RoleContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ERoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
