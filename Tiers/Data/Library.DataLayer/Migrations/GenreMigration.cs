using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Genres;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class GenreMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IGenreRepository _genrerepo;


        public GenreMigration(IMigrationRepository migrationrepo, IGenreRepository genrerepo)
        {
            _migrationrepo = migrationrepo;
            _genrerepo = genrerepo;
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

                var genres = new[]
                {
                    "Anlatı"
                    , "Oyun"
                    , "Şiir"
                    , "Roman"
                    , "Felsefe"
                    , "Günce"
                    , "Şarkılar"
                    , "Sözlük"
                    , "Öykü"
                    , "Aforizmalar"
                    , "Destan"
                    , "Tarih"
                    , "Tiyatro"
                    , "Seçme"
                    , "Deneme"
                    , "Strateji"
                    , "Derleme"
                    , "Araştırma"
                    , "Biografi"
                    , "Çizgi Roman"
                    , "Bilim Kurgu"
                    , "Mektup"
                    , "Çocuk"
                    , "Fantastik"
                    , "Söyleşi"
                    , "Lugat"
                    , "Fotoğraf"
                };


                //var genrerepo = IoCManager.Container.Resolve<IGenreRepository>();

                foreach (var genre in genres)
                {
                    _genrerepo.CreateEntity(new EGenre
                    {
                        Genre = genre,
                        CreatedDateTime = DateTime.Now
                    });
                }

            }
        }

        public string Name
        {
            get { return "00002_GenreMigration"; }
        }
    }
}

