using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Publishers;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class PublisherMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IPublisherRepository _publisher;

        public PublisherMigration(IMigrationRepository migrationrepo, IPublisherRepository publisher)
        {
            this._migrationrepo = migrationrepo;
            this._publisher = publisher;
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

                //var publisher = IoCManager.Container.Resolve<IPublisherRepository>();

                _publisher.CreateEntity(new EPublisher() { Name = "Aganta", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Albatros", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "AltıKırkbeş", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Altın Bilek", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Ayrıntı", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Bilge", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Bilgi", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Can", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Dogan Kitap", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Domingo", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Epsilon", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "İletişim", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "İlke Kitap", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "İthaki", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Jaguar", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Kabalcı", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Kaktüs", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Kırmızı Kedi", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Marmara Çizgi", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Metis", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Pegasus", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Pinhan", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Say", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Sel", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Tefrika", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Türkiye İş Bankası", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Yapı Kredi Yayınları", CreatedDateTime = DateTime.Now });
                _publisher.CreateEntity(new EPublisher() { Name = "Zeplin", CreatedDateTime = DateTime.Now });
            }


        }

        public string Name
        {
            get { return "00005_PublisherMigration"; }
        }
    }
}
