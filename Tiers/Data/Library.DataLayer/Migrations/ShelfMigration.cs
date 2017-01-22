using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Racks;
using Library.Data.Repositories.Shelfs;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class ShelfMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IShelfRepository _shelfrepository;
        private readonly IRackRepository _rackrepository;

        public ShelfMigration(IMigrationRepository migrationrepo, IShelfRepository shelfrepository, IRackRepository rackrepository)
        {
            _migrationrepo = migrationrepo;
            _shelfrepository = shelfrepository;
            _rackrepository = rackrepository;
        }

        public void Migrate()
        {
            //var migrationrepo = IoCManager.Container.Resolve<IMigrationRepository>();

            var entity = _migrationrepo.GetAll().Any(x => x.Name == Name);

            if (!entity)
            {
                _migrationrepo.CreateEntity(new EMigration()
                {
                    Name = Name,
                    CreatedDateTime = DateTime.Now
                });

                //var shelfrepository = IoCManager.Container.Resolve<IShelfRepository>();
                //var rackrepository = IoCManager.Container.Resolve<IRackRepository>();

                var racks = _rackrepository.GetAll();

                var firstShelf = new EShelf()
                {
                    Name = "Kitaplık 1",
                    CreatedDateTime = DateTime.Now,
                    Racks = racks.ToList()
                };
                var secondShelf = new EShelf()
                {
                    Name = "Kitaplık 2",
                    CreatedDateTime = DateTime.Now,
                    Racks = racks.ToList()
                };
                var thirdShelf = new EShelf()
                {
                    Name = "Kitaplık 3",
                    CreatedDateTime = DateTime.Now,
                    Racks = racks.ToList()
                };

                _shelfrepository.CreateEntity(firstShelf);
                _shelfrepository.CreateEntity(secondShelf);
                _shelfrepository.CreateEntity(thirdShelf);
               // shelfrepository.CreateEntity(new EShelf() {Name = "Kütüphane 2",CreatedDateTime = DateTime.Now});
            }
        }

        public string Name { get { return "00004_ShelfMigration"; } }
    }
}
