using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Publishers;
using Library.Data.Repositories.Series;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class SeriesMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly ISeriesRepository _seriesrepository;
        private readonly IPublisherRepository _publisherrepository;

        public SeriesMigration(IMigrationRepository migrationrepo, ISeriesRepository seriesrepository, IPublisherRepository publisherrepository)
        {
            _migrationrepo = migrationrepo;
            _seriesrepository = seriesrepository;
            _publisherrepository = publisherrepository;
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

                //var seriesrepository = IoCManager.Container.Resolve<ISeriesRepository>();

                //var publisherrepository = IoCManager.Container.Resolve<IPublisherRepository>();

                var tis = _publisherrepository.GetAll().FirstOrDefault(x => x.Name == "Türkiye İş Bankası");
                var yky = _publisherrepository.GetAll().FirstOrDefault(x => x.Name == "Yapı Kredi Yayınları");
                var ilt = _publisherrepository.GetAll().FirstOrDefault(x => x.Name == "İletişim");

                _seriesrepository.CreateEntity(new ESeries {Name = "Hasan Ali Yücel Klasikleri",CreatedDateTime = DateTime.Now , Publisher = tis});
                _seriesrepository.CreateEntity(new ESeries {Name = "Modern Klasikler Dizisi",CreatedDateTime = DateTime.Now , Publisher = tis});
                _seriesrepository.CreateEntity(new ESeries {Name = "Kazım Taşkent Klasikleri",CreatedDateTime = DateTime.Now,Publisher = yky});
                _seriesrepository.CreateEntity(new ESeries {Name = "Klasikler", CreatedDateTime = DateTime.Now,Publisher = ilt});

            }


        }

        public string Name { get { return "00006_SeriesMigration"; } }
    }
}
