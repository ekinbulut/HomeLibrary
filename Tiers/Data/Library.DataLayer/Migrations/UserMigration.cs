using System;
using System.Linq;
using Library.DataLayer.Entities;
using Library.DataLayer.Repositories.Migrations;
using Library.DataLayer.Repositories.Roles;
using Library.DataLayer.Repositories.Users;
using SenseFramework.Data.EntityFramework.Migrations;

namespace Library.DataLayer.Migrations
{
    public class UserMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IUserRepository _userrepo;
        private readonly IRoleRepository _roleepo;

        public UserMigration(IMigrationRepository migrationrepo, IUserRepository userrepo, IRoleRepository roleepo)
        {
            this._migrationrepo = migrationrepo;
            this._userrepo = userrepo;
            this._roleepo = roleepo;
        }

        public void Migrate()
        {
            //var migrationrepo = IoCManager.Container.Resolve<IMigrationRepository>();

            var entity = _migrationrepo.GetAll().Any(x => x.Name == this.Name);

            if (!entity)
            {
                _migrationrepo.CreateEntity(new EMigration()
                {
                    Name = this.Name,
                    CreatedDateTime = DateTime.Now
                });

                //var userrepo = IoCManager.Container.Resolve<IUserRepository>();
                //var roleepo = IoCManager.Container.Resolve<IRoleRepository>();

                _userrepo.CreateEntity(new EUser()
                {
                    Name = "System User",
                    Userame = "admin@admin.com",
                    Password = "p@ssw0rd",
                    CreatedDateTime = DateTime.Now,
                    ERole = _roleepo.GetOne(1),
                    IsActive = true,
                    LastLoginDate = DateTime.Now,
                    Occupation = "Developer",
                    Gender = Gender.Male
                });
            }
        }

        public string Name
        {
            get { return "00009_UserMigration"; }
        }
    }
    
}
