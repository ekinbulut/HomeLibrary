using System;
using System.Linq;
using Library.DataLayer.Entities;
using Library.DataLayer.Repositories.Migrations;
using Library.DataLayer.Repositories.Roles;
using SenseFramework.Data.EntityFramework.Migrations;

namespace Library.DataLayer.Migrations
{
    public class RoleMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IRoleRepository _rolerepo;

        public RoleMigration(IMigrationRepository migrationrepo, IRoleRepository rolerepo)
        {
            _migrationrepo = migrationrepo;
            _rolerepo = rolerepo;
        }

        public string Name { get { return "00001_RoleMigration"; } }

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

                //var rolerepo = IoCManager.Container.Resolve<IRoleRepository>();

                _rolerepo.CreateEntity(new ERole() { Name = "Administrator", CreatedDateTime = DateTime.Now });
                _rolerepo.CreateEntity(new ERole() { Name = "User", CreatedDateTime = DateTime.Now });
                _rolerepo.CreateEntity(new ERole() { Name = "Preminium", CreatedDateTime = DateTime.Now });

            }

        }
    }
}
