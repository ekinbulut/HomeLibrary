using System;
using System.Linq;
using Library.DataLayer.Entities;
using Library.DataLayer.Repositories.Migrations;
using Library.DataLayer.Repositories.Racks;
using SenseFramework.Data.EntityFramework.Migrations;

namespace Library.DataLayer.Migrations
{
    public class RackMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private IRackRepository _rackRepository;

        public RackMigration(IMigrationRepository migrationrepo, IRackRepository rackRepository)
        {
            this._migrationrepo = migrationrepo;
            this._rackRepository = rackRepository;
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

                //var rackrepository = IoCManager.Container.Resolve<IRackRepository>();

                _rackRepository.CreateEntity(new ERack() {RackNumber = 1, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack() {RackNumber = 2, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack() {RackNumber = 3, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack() {RackNumber = 4, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack() {RackNumber = 5, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack() {RackNumber = 6, CreatedDateTime = DateTime.Now});
            }
        }

        public string Name { get { return "00003_RackMigration"; } }
    }
}
