using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Racks;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class RackMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private IRackRepository _rackRepository;

        public RackMigration(IMigrationRepository migrationrepo, IRackRepository rackRepository)
        {
            _migrationrepo = migrationrepo;
            _rackRepository = rackRepository;
        }

        public void Migrate()
        {
            //var migrationrepo = IoCManager.Container.Resolve<IMigrationRepository>();

            var entity = _migrationrepo.GetAll().Any(x => x.Name == Name);

            if (!entity)
            {
                _migrationrepo.CreateEntity(new EMigration
                {
                    Name = Name,
                    CreatedDateTime = DateTime.Now
                });

                //var rackrepository = IoCManager.Container.Resolve<IRackRepository>();

                _rackRepository.CreateEntity(new ERack {RackNumber = 1, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 2, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 3, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 4, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 5, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 6, CreatedDateTime = DateTime.Now});
                _rackRepository.CreateEntity(new ERack {RackNumber = 7, CreatedDateTime = DateTime.Now});
            }
        }

        public string Name { get { return "00003_RackMigration"; } }
    }
}
