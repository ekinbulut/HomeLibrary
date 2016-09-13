using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data.Book.Repositories.Books;
using Library.Data.Entities;
using Library.Data.Enums;
using Library.Data.Repositories.Authors;
using Library.Data.Repositories.Genres;
using Library.Data.Repositories.Publishers;
using Library.Data.Repositories.Racks;
using Library.Data.Repositories.Series;
using Library.Data.Repositories.Shelfs;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Book.Migrations
{
    public class BookMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;

        private readonly IShelfRepository shelfrepos;
        private readonly IAuthorRepository authorrepos;
        private readonly IGenreRepository genrerepos;
        private readonly IPublisherRepository publisherrepos;
        private readonly IRackRepository rackrepos;
        private readonly ISeriesRepository seriesrepo;
        private readonly IBookRepository bookrepos;

        public BookMigration(IMigrationRepository migrationrepo, IShelfRepository shelfrepos, IAuthorRepository authorrepos, IGenreRepository genrerepos, IPublisherRepository publisherrepos, IRackRepository rackrepos, ISeriesRepository seriesrepo, IBookRepository bookrepos)
        {
            this._migrationrepo = migrationrepo;
            this.shelfrepos = shelfrepos;
            this.authorrepos = authorrepos;
            this.genrerepos = genrerepos;
            this.publisherrepos = publisherrepos;
            this.rackrepos = rackrepos;
            this.seriesrepo = seriesrepo;
            this.bookrepos = bookrepos;
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

                var list = new List<Book>()
                {
                    new Book()
                    {
                        Author = "Aiskhylos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Zincire Vurulmuş Prometheus",
                        No = "CXCII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Aisopos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Masallar",
                        No = "CCII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Aleksander Sergeyeviç Puşkin",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Boris Godunov",
                        No = "CLXXV",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Aleksander Sergeyeviç Puşkin",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Seviyordum Sizi",
                        No = "XXXII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Aleksander Sergeyeviç Puşkin",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Yüzbaşının Kızı",
                        No = "XXXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Alexandre Dumas",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Binbir Hayalet",
                        No = "LXXX",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Alexandre Dumas",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kamelyalı Kadın",
                        No = "XX",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Alexandre Dumas",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Üç Silahşör",
                        No = "CVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Alfred De Musset",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Lorenzaccio",
                        No = "CCLVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Alfred De Musset",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Marianne’in Kalbi",
                        No = "CLXXIII",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Alfred De Musset",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Şamdancı",
                        No = "CCLXV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Anton Pavloviç Çehov",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Ayı",
                        No = "CLXXXVI",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Anton Pavloviç Çehov",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Büyük Oyunlar",
                        No = "XXXVI",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Anton Pavloviç Çehov",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Köpeğiyle Dolaşan Kadın",
                        No = "XXXV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Baki",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Divan",
                        No = "CCLX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Calderon De La Barca",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Hayat Bir Rüyadır",
                        No = "XIV",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Carlo Goldini",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Lokantacı Kadın",
                        No = "CCXLVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Carlo Goldini",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Sevgililer",
                        No = "CCXXVI",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Charles Baudelaire",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Kötülük Çiçekleri",
                        No = "CCLIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Charles Baudelaire",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Günce",
                        Name = "Özel Günceler",
                        No = "CCXLI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Cicero",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Yükümlülükler Üzerine",
                        No = "CXCVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Daniel Defoe",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Robinson Crusoe",
                        No = "CLXXX",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Rahibe",
                        No = "CCLXVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Aktörlük Üzerine Aykırı Düşünceler",
                        No = "LXIV",
                        Publish_Date = "2007",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Körler Üzerine Mektup",
                        No = "CLXVII",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Rameau’nun Yeğeni",
                        No = "CXCVIII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Felsefe Konuşmaları",
                        No = "CCVI",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "E.T.A. Hoffman",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Seçme Masallar",
                        No = "LXXXII",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Edgar Allan Poe",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Dedektif",
                        No = "XIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Edib Ahmed Yükneki",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Atebetü’l Hakayık",
                        No = "CCLXVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Emile Zola",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Nana",
                        No = "CCLVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Emile Zola",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Yaşama Sevinci",
                        No = "CXCIV",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Emily Dickinson",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Seçme Şiirler",
                        No = "XIX",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Euripides",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Bakkhalar",
                        No = "CXXXVII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Euripides",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Medea",
                        No = "CCXV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Euripides",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Resos",
                        No = "CLXIII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Euripides",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Yakarıcılar",
                        No = "CLII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Böyle Söyledi Zerduşt",
                        No = "CLVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "David Strauss, İtirafçı ve Yazar",
                        No = "CCLXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Dionysıs Dithyrambosları",
                        No = "CLX",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Ecce Homo",
                        No = "CXVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Eğitici Olarak Schopen Hauer",
                        No = "CCLXIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "İnsanca Pek İnsanca -1 ",
                        No = "CLXXXV -1",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "İnsanca Pek İnsanca-Gezgin ve Gölgesi",
                        No = "CLXXXV -3",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "İnsanca Pek İnsanca-Karışık Kanılar ve Özdeyişler",
                        No = "CLXXXV -2",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Putların Alacakaranlığı",
                        No = "CXXXIV",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Richard Wagner Bayreuth’ta",
                        No = "XXLXIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Tarihin Yaşam İçin Yararı ve Sakıncası",
                        No = "CCLXII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Tragedyanın Doğuşu",
                        No = "CXXIV",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Beyaz Geceler",
                        No = "CCXXVII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Budala",
                        No = "CLXV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ecinniler",
                        No = "CLXXIV",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ev Sahibesi",
                        No = "CXLIV",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ezilenler",
                        No = "LXXIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kramazov Kardeşler",
                        No = "LXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kumarbaz",
                        No = "CXCV",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ölüler Evinden Anılar",
                        No = "LXXXVII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Öteki",
                        No = "CXXXIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Stepançikovo Köyü",
                        No = "CXXI",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Suç ve Ceza",
                        No = "XLV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Yeraltından Notlar",
                        No = "XC",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Galileo Galilei",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "İki Büyük Dünya Sistemi Hakkında Dialog",
                        No = "LXXXVI",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "George Eliot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Silas Marner",
                        No = "CLXX",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Giacomo Leopardi",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şarkılar",
                        Name = "Şarkılar",
                        No = "CCLXXII",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Gustave Flaubert",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Ermiş Antonius ve Şeytan",
                        No = "XIV",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Gustave Flaubert",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Sözlük",
                        Name = "Yerleşik Düşünceler Sözlüğü",
                        No = "XV",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Guy De Maupassant",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Gezgin Satıcı",
                        No = "CI",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Guy De Maupassant",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Güzel Dost",
                        No = "CLXII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Hayyam",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Dörtlükler",
                        No = "XXI",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Heinrich Von Kleist",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Öykü",
                        Name = "Düello - Bütün Öyküleri",
                        No = "CXLII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Henri Bergson",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Gülme",
                        No = "CCXVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Henry James",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Güvercinin Kanatları",
                        No = "C",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Henry James",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kısa Romanlar, Uzun Öyküler",
                        No = "LIX",
                        Publish_Date = "2007",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Henry James",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Yürek Burgusu",
                        No = "VI",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Herodas",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Mimoslar",
                        No = "CCLXXIII",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Hippokrates",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Aforizmalar",
                        Name = "Aforizmalar",
                        No = "CCLXXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Homeros",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Destan",
                        Name = "İlyada",
                        No = "CCXIX",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Homeros",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Odysseia",
                        No = "CCXX",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Bir Havva Kızı",
                        No = "CIII",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Evde Kalmış Kız",
                        No = "LXXXI",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Louis Lambert",
                        No = "CXLVI",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Modeste Mignon",
                        No = "VIII",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Mutlak Peşinde",
                        No = "CLXXI",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Pierrette",
                        No = "CXXVII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Suyu Bulandıran Kız",
                        No = "CXII",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Tılsımlı Deri",
                        No = "CXX",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Honore De Balzac",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ursule Mirouet",
                        No = "LIII",
                        Publish_Date = "2007",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "İbn Kalanisi",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tarih",
                        Name = "Şam Tarihine Zeyl",
                        No = "CCXLIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "İsa Öztürk",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kerem İle Aslı",
                        No = "V",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "İvan A. Gonçarov",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Oblomov",
                        No = "XXVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ivan Sergeyeviç Turgenyev",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Babalar ve Oğullar",
                        No = "XXXIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ivan Sergeyeviç Turgenyev",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tiyatro",
                        Name = "Başkanın Ziyafeti - Parasızlık - Bekar",
                        No = "CCLXIX",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ivan Sergeyeviç Turgenyev",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Duman",
                        No = "CLXXVII",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ivan Sergeyeviç Turgenyev",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ham Toprak",
                        No = "CCLIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ivan Sergeyeviç Turgenyev",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Rudin - İlk Aşk İlkbahar Selleri",
                        No = "CVIII",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jane Austen",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Akıl ve Tutku",
                        No = "LXXIV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jane Austen",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Gurur ve Önyargı",
                        No = "I",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jane Austen",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Northanger Manastırı",
                        No = "CLXXIX",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Johann W. Von Goethe",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Alman Göçmenlerinin Sohbetleri",
                        No = "CCXXXVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Johann W. Von Goethe",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Yarat Ey Sanatçı",
                        No = "XI",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Johann W. Von Goethe",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Yaşamımdan Şiir ve Hakikat",
                        No = "CX",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jonathan Swift",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Alçakgönüllü Bir Öneri",
                        No = "XCVI",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Katherine Mansfield",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Öykü",
                        Name = "Katıksız Mutluluk",
                        No = "CXV",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Kolektif",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Destan",
                        Name = "Gılgamış Destanı",
                        No = "CCXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Kristof Kolomb",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Seyir Defterleri",
                        No = "CCXLVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ksenophon",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Anabasis",
                        No = "CCLVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Anna Karenina",
                        No = "CLXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Çocukluk",
                        No = "CCXXX",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Diriliş",
                        No = "CXI",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Gençlik",
                        No = "CCLV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Hacı Murat",
                        No = "LXXXV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "İlk Gençlik",
                        No = "CCXLV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "İnsan Ne İle Yaşar",
                        No = "CLXXXIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "İvan İlyiçi'nin Ölümü",
                        No = "CCXXIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kafkas Tutsağı",
                        No = "CXXVIII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kreutzer Sonat",
                        No = "CC",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Sanat Nedir ?",
                        No = "LXIX",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Sivastopol",
                        No = "CIX",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Üç Ölüm",
                        No = "CCIX",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "M.Y. Lermantov",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Hançer",
                        No = "CCXXXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Mark Twain",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Seçme",
                        Name = "Seçme Öyküler",
                        No = "LXXXIV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Mevlana",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Divan-I Kebir",
                        No = "LXXI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Michelangelo",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Cennetin Anahtarları",
                        No = "CCLXVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Miguel De Cervantes",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Yüce Sultan",
                        No = "LXXVI",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Moliere",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Cimri",
                        No = "XXXVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Moliere",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "George Dandin",
                        No = "CLIV",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Moliere",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "İnsandan Kaçan",
                        No = "CCVIII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Moliere",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kadınlar Mektebi",
                        No = "CXVIII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Montesquieu",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "İran Mektupları",
                        No = "CCLII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Akşam Toplantıları",
                        No = "XL",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Bir Delinin Anı Defteri – Palto – Burun",
                        No = "XLVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Evlenme Kumarbazlar",
                        No = "CLXXXIV",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Müfettiş",
                        No = "CXVIII",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Ölü Canlar",
                        No = "CXXXIX",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Taras Bulba ve Mirgorod Öyküleri",
                        No = "CXXX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "2",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Novalis",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Geceye Övgüler",
                        No = "II",
                        Publish_Date = "2006",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Platon",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Devlet",
                        No = "XXIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Platon",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Gorgias",
                        No = "XII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Platon",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Sokrates’in Savunması",
                        No = "CLXXXII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Platon",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Şölen Dostluk",
                        No = "XXX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Plutarkhos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "İskender - Sezar",
                        No = "CCLI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Plutarkhos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Anlatı",
                        Name = "Lykurgos’un Hayatı",
                        No = "CXL",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Plutarkhos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Theseus - Romulus",
                        No = "CCXLIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Prokopios",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tarih",
                        Name = "Bizans’ın Gizli Tarihi",
                        No = "XCI",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Aias",
                        No = "CCXLIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Antigone",
                        No = "CCXXVIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Elektra",
                        No = "CLXXVIII",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral Oidipus",
                        No = "CLXIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Philoktetes",
                        No = "CCXLVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sophokles",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Trakhisli Kadınlar",
                        No = "CCXXXII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Sun Zi",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Strateji",
                        Name = "Savaş Sanatı",
                        No = "CCXXXIV",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Tsunetomo Yamamoto",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Hagakure : Saklı Yapraklar",
                        No = "XLIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Valenciennes",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tarih",
                        Name = "IV. Haçlı Seferi Kronikleri",
                        No = "XCIII",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Vicente Blasco Ibanez",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Mahşerin Dört Atlısı",
                        No = "XCIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Victor Hugo",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Bir İdam Mahkumunun Son Günü",
                        No = "CCV",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Victor Hugo",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Notre Dame'in Kamburu",
                        No = "CCXIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Victor Hugo",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Sefiller",
                        No = "CCL",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Antonius ve Kleopatra",
                        No = "XXXIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Aşk ve Anlatı Şiirleri",
                        No = "CCXXV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Aşkın Emeği Boşuna",
                        No = "CCCXXIV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Atinalı Timon",
                        No = "LXXIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Bir Yaz Gecesi Rüyası",
                        No = "CLVII",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Cardenio",
                        No = "CLIII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Coriolanus’un Tregedyası",
                        No = "CCXIV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Cymbeline",
                        No = "CCIII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Fırtına",
                        No = "CCXLII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Hırçın Kız",
                        No = "CLXXVI",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "II. Richard",
                        No = "CCXXXIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "III. Richard",
                        No = "LXX",
                        Publish_Date = "2007",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "İki Soylu Akraba",
                        No = "CLXXXI",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Julius Caesar",
                        No = "LVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kış Masalı",
                        No = "CCXVIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kısasa Kısas",
                        No = "CLXXII",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral IV. Henry - I",
                        No = "CCXXI",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral IV. Henry - II",
                        No = "CCXXII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral John’un Yaşamı ve Ölümü",
                        No = "CXLV",
                        Publish_Date = "2011",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral Lear",
                        No = "CIV",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral V. Henry",
                        No = "CXCIX",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral VI. Henry - I",
                        No = "CCXXXV",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral VI. Henry - II",
                        No = "CCXXXVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral VI. Henry - III",
                        No = "CCXXXVII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kral VIII. Henry ",
                        No = "CLXVI",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Kuru Gürültü",
                        No = "XCVIII",
                        Publish_Date = "2008",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Macbeth",
                        No = "XXXVIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Nasıl Hoşunuza Giderse",
                        No = "CXCI",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "On ikinci gece",
                        No = "CXXXI",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Othello",
                        No = "XCII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Pericles",
                        No = "LXVIII",
                        Publish_Date = "2007",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Romeo ve Juliet",
                        No = "CXXIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Şiir",
                        Name = "Soneler",
                        No = "CXIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Titus Andronicus",
                        No = "CCXXIX",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Troilus ve Cressida",
                        No = "CCXVI",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Venedik Taciri",
                        No = "CLXIX",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Veronalı İki Soylu Delikanlı",
                        No = "CCVII",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Windsor’un Şen Kadınları",
                        No = "CCXXXIX",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Yanlışlıklar Komedyası",
                        No = "CXLI",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Oyun",
                        Name = "Yeter ki Sonu İyi Bitsin",
                        No = "CXXXVIII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Yusuf Has Hacib",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tarih",
                        Name = "Kutadgu Bilig",
                        No = "CCXLIV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Anthony Burgess",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Bir Elin Sesi Var",
                        No = "41",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Anthony Burgess",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Mozart ve Deyyuslar",
                        No = "24",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Anthony Burgess",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Otomatik Portakal",
                        No = "3",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Anton Pavloviç Çehov",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Martı",
                        No = "34",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Anton Pavloviç Çehov",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Oyun",
                        Name = "Vanya Dayı",
                        No = "35",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Bernard Shaw",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Oyun",
                        Name = "Dört Oyun",
                        No = "9",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Carson McCullers",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Altın Gözde Yansımalar",
                        No = "29",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Carson McCullers",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Küskün Kahvenin Türküsü",
                        No = "17",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "F.Scott Fitzgerald",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Muhteşem Gatsby",
                        No = "63",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Aforizmalar",
                        Name = "Aforizmalar",
                        No = "7",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Dava",
                        No = "49",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Dönüşüm",
                        No = "26",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Şato",
                        No = "43",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Giovanni Papini",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "GOG",
                        No = "56",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Halil Cibran",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Anlatı",
                        Name = "Ermiş",
                        No = "28",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Halil Cibran",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Öykü",
                        Name = "Gezginler",
                        No = "67",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Halil Cibran",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Aforizmalar",
                        Name = "Kum ve Köpük",
                        No = "32",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Halil Cibran",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Şiir",
                        Name = "Meczup",
                        No = "45",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Henry James",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Bir Hanım Efendinin Portresi",
                        No = "36",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Beyaz Diş",
                        No = "10",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Demir Ökçe",
                        No = "23",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Deniz Kurdu",
                        No = "31",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Martin Eden",
                        No = "38",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Vahşetin Çağrısı",
                        No = "6",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jack London",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Yıldız Gezegeni",
                        No = "44",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "James Joyce",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Şiir",
                        Name = "Oda Müziği Tüm Şiirleri",
                        No = "16",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Dos Passos",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "A.B.D. 1919",
                        No = "20",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Dos Passos",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Enlem",
                        No = "13",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Joseph Conrad",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Casus",
                        No = "4",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Katherine Mansfield",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Bahçede Eğlence",
                        No = "19",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Katherine Mansfield",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Çocuksu Bir Şey",
                        No = "25",
                        Publish_Date = "2013",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Maksim Gorki",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Ayaktakımı Arasında",
                        No = "39",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Maksim Gorki",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Biografi",
                        Name = "Benim Universitlerim",
                        No = "68",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Maksim Gorki",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Çocukluğum",
                        No = "37",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Maksim Gorki",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Ekmeğimi Kazanırken",
                        No = "60",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Maksim Gorki",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Küçük Burjuvalar",
                        No = "46",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Mark Twain",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Huckleberry Finn’in Maceraları",
                        No = "33",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Miguel De Unamuno",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Üç Örnek Öykü ve Bir Önsöz",
                        No = "11",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Mihail Bulgakov",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Genç Bir Doktorun Anıları",
                        No = "47",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Mihail Bulgakov",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Köpek Kalbi",
                        No = "64",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Mihail Bulgakov",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Ölümcül Yumurtalar",
                        No = "58",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Pablo Neruda",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Şiir",
                        Name = "Yirmi Aşk Şiiri ve Umutsuz bir Şarkı",
                        No = "42",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Paul Celan",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Ellerin Zamanlarla Dolu",
                        No = "51",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Rabindranath Tagore",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Şiir",
                        Name = "Gitanjali",
                        No = "48",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Rainer Maria Luke",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Şiir",
                        Name = "Bütün Şiirlerinden Seçmeler",
                        No = "40",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Robert Graves",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Ben, Claudius",
                        No = "50",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Robert Louis Stevenson",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Dr. Jekyll ile Bay Hyde",
                        No = "62",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sir Arthur Conan Doyle",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Korku Vadisi",
                        No = "5",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sir Athur Conan Doyle",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Dörtlerin Yemini",
                        No = "12",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Bilinmeyen Kadının Mektubu",
                        No = "22",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Bir Kadının Yaşamından Yirmi Dört Saat",
                        No = "52",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Gömülü Şamdan",
                        No = "65",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Karmaşık Duygular",
                        No = "55",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Biografi",
                        Name = "Kendi Hayatının Şiirini Yazanlar- Casanova - Stendhal - Tolstoy",
                        No = "18",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Biografi",
                        Name = "Kendileriyle Savaşanlar",
                        No = "15",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Korku",
                        No = "57",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Öykü",
                        Name = "Mürebbiye",
                        No = "69",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Olağanüstü Bir Gece",
                        No = "66",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Satranç",
                        No = "21",
                        Publish_Date = "2012",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Biografi",
                        Name = "Üç Büyük Usta",
                        No = "14",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Stefan Zweig",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Yakıcı Sır",
                        No = "61",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Virginia Woolf",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Deniz Feneri",
                        No = "53",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Golding",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Çatal Dil",
                        No = "59",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Golding",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Kule",
                        No = "27",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Golding",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Piramit",
                        No = "54",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Golding",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Sineklerin Tanrısı",
                        No = "1",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Shakespeare",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tiyatro",
                        Name = "Hamlet",
                        No = "LXXVIII",
                        Publish_Date = "2010",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Charles Baudelaire",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Paris Sıkıntısı",
                        No = "XVI",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Emile Zola",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Germinal",
                        No = "CXXXV",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Herodotos",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Felsefe",
                        Name = "Tarih",
                        No = "XXVIII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Montaigne",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Deneme",
                        Name = "Denemeler",
                        No = "XXIII",
                        Publish_Date = "2015",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "5",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Denis Diderot",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Roman",
                        Name = "Kaderci Jacques ve Efendisi",
                        No = "CCXII",
                        Publish_Date = "2014",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Moliere",
                        Description = "Hasan Ali Yücel Klasikleri",
                        Genre = "Tiyatro",
                        Name = "Hastalık Hastası",
                        No = "CCLXXIV",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "6",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Aleksander Sergeyeviç Puşkin",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Şiir",
                        Name = "Poemalar",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Dionysios Byzantios",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Anlatı",
                        Name = "Boğaziçi’nde Bir Gezinti",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Derleme",
                        Name = "Bir Yazarın Günlüğü",
                        No = "",
                        Publish_Date = "2012",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Herman Melville",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Roman",
                        Name = "Moby Dick",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "James Joyce",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Roman",
                        Name = "Ulysses",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Karl R. Popper",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Araştırma",
                        Name = "Bilimsel Araştırmalar Mantığı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Leonardo Da Vinci",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Araştırma",
                        Name = "Yazılar",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Miguel De Cervantes",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Roman",
                        Name = "Don Quijote",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Mihail Yuryeviç Lermontov",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Şiir",
                        Name = "Özgürlüğün Son Oğlu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Klasikler",
                        Genre = "Roman",
                        Name = "İnsancıklar",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Klasikler",
                        Genre = "Roman",
                        Name = "Netoçka Nezvanova",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Klasikler",
                        Genre = "Anlatı",
                        Name = "Puşkin Konuşması",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "Klasikler",
                        Genre = "Roman",
                        Name = "Yaz İzlenimleri Üzerine Kış Notları",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Nikolay Vasilyeviç Gogol",
                        Description = "Klasikler",
                        Genre = "Öykü",
                        Name = "Petersburg Öyküleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Louis-Ferdinand Celine",
                        Description = "Kazım Taşkent Klasikleri",
                        Genre = "Roman",
                        Name = "Gecenin Sonuna Yolculuk",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Robert Graves",
                        Description = "Modern Klasikler Dizisi",
                        Genre = "Roman",
                        Name = "Tanrı, Claudius",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "4",
                        Shelf = "Kitaplık 1",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Adrian Furnham",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "50 Psikoloji Fikri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Domingo",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Albert Camus",
                        Description = "",
                        Genre = "Deneme",
                        Name = "Başkaldıran İnsan",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Albert Camus",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yabancı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Albert Camus",
                        Description = "",
                        Genre = "Roman",
                        Name = "Düşüş",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Aldous Huxley",
                        Description = "",
                        Genre = "Roman",
                        Name = "Ada",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Aldous Huxley",
                        Description = "",
                        Genre = "Roman",
                        Name = "Cesur Yeni Dünya",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Aleksander Sergeyeviç Puşkin",
                        Description = "",
                        Genre = "Şiir",
                        Name = "Yevgeniy Onegin",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Ayrıntı",
                        RackNo = "5",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Aleksandros Papadiamantis",
                        Description = "",
                        Genre = "Roman",
                        Name = "Hadula",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Jaguar",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Alessandro Baricco",
                        Description = "",
                        Genre = "Roman",
                        Name = "Şafakta Üç Kez",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Antoine de Saint-Exupery",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Küçük Prens",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Apostolos Doksiadis",
                        Description = "",
                        Genre = "Çizgi Roman",
                        Name = "Logicomix",
                        No = "",
                        Publish_Date = "2012",
                        Publisher = "Albatros",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Arkadi - Boris Strugatski",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Kıyamete Bir Milyar Yıl",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Arthur C. Clarke",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Çocukluğun Sonu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Barış Bıçakçı",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Seyrek Yağmur",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ben Dupre",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "50 Felsefe Fikri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Domingo",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ben Lerner",
                        Description = "",
                        Genre = "Roman",
                        Name = "Atocha'dan Ayrılış",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Jaguar",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Brain K. Vaughan",
                        Description = "",
                        Genre = "Çizgi Roman",
                        Name = "Saga",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Marmara Çizgi",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Cahit Sıtkı Tarancı",
                        Description = "",
                        Genre = "Şiir",
                        Name = "Otuz Beş Yaş - Bütün Şiirleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Carlos Maria Dominguez",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kağıt Ev",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Jaguar",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Carmine Gallo",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "TED Gibi Konuş",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Aganta",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Cixin Liu",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Üç Cisim Problemi",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Derleme",
                        Description = "",
                        Genre = "Derleme",
                        Name = "50 Muhteşem kısa hikaye",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Tefrika",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Douglas Adams",
                        Description = "",
                        Genre = "Roman",
                        Name = "Otostopçunun Galaksi Rehberi",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Kabalcı",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Edgar Allan Poe",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Bütün Öyküleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Edgar Allan Poe",
                        Description = "",
                        Genre = "Şiir",
                        Name = "Bütün Şiirleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Edgar Allan Poe",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Kuyu ve Sarkaç",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Emilie Kip Baker",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "Antik Yunan ve Roma Hikayeleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Altın Bilek",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ernest Hemingway",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yaşlı Adam ve Deniz",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Bilgi",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fernando Pessoa",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Hiçbir şey İstememenin Mutluluğu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Aforizmalar",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "AltıKırkbeş",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "",
                        Genre = "Mektup",
                        Name = "Babaya Mektup",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "",
                        Genre = "Roman",
                        Name = "Dönüşüm",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "",
                        Genre = "Mektup",
                        Name = "Milena’ya Mektuplar",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Franz Kafka",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Yalnızlık Sahip Olduğum Tek Şey",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Freud",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Mutlu Olma İhtimalimiz",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Friedrich Nietzsche",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Herşey Dökülmüş Müydü Kelimelere",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "",
                        Genre = "Roman",
                        Name = "Amcanın Düşü",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "",
                        Genre = "Çocuk",
                        Name = "Çocuklarla Beraber",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Dünyayı Güzellik Kurtaracak",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Fyodor M. Dostoyevski",
                        Description = "",
                        Genre = "Roman",
                        Name = "İkiz",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "George Frazer",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "İnsan, Tanrı ve Ölümsüzlük",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Altın Bilek",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "1984",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "Balinanın Karnında",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "Boğulmamak için Yaşamak",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "Burma Günleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "Hayvan Çiftliği",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "George Owell",
                        Description = "",
                        Genre = "Roman",
                        Name = "Paris ve Londra’da Beş Parasız",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Gündüz Vassaf",
                        Description = "",
                        Genre = "Roman",
                        Name = "Cehenneme Övgü",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Gündüz Vassaf",
                        Description = "",
                        Genre = "Roman",
                        Name = "Cennetin Dibi",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "H.G. Wells",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Doktor Moreau’nun Adası",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "H.G. Wells",
                        Description = "",
                        Genre = "Roman",
                        Name = "Dünyaların Savaşı",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "H.G. Wells",
                        Description = "",
                        Genre = "Roman",
                        Name = "Görünmez Adam",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "H.G. Wells",
                        Description = "",
                        Genre = "Roman",
                        Name = "Zaman Makinesi",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Hagop Baronyan",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "İstanbul Mahallelerinde Bir Gezi",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Harper Lee",
                        Description = "",
                        Genre = "Roman",
                        Name = "Bülbülü Öldürmek",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Sel",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Harper Lee",
                        Description = "",
                        Genre = "Roman",
                        Name = "Tespih Ağacının Gölgesinde",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Sel",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "1Q84",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Uyku",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Irvin D. Yalom",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Günü Birlik Hayatlar",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Pegasus",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Irvin D. Yalom",
                        Description = "",
                        Genre = "Roman",
                        Name = "Nietzsche Ağladığında",
                        No = "",
                        Publish_Date = "1997",
                        Publisher = "Ayrıntı",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "J. D. Salinger",
                        Description = "",
                        Genre = "Roman",
                        Name = "Çavdar Tarlasında Çocuklar",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "J.M.Coetzee",
                        Description = "",
                        Genre = "Roman",
                        Name = "Utanç",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "J.R.R. Tolkien",
                        Description = "",
                        Genre = "Fantastik",
                        Name = "Hobbit",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "J.R.R. Tolkien",
                        Description = "",
                        Genre = "Fantastik",
                        Name = "Yüzüklerin Efendisi",
                        No = "",
                        Publish_Date = "2012",
                        Publisher = "Metis",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jacob Abbott",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "Büyük İskender",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Altın Bilek",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "James Joyce",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Gözünü Kapat ve Gör",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jean-Pierre Vernant",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "İlk Kadın Pandora",
                        No = "",
                        Publish_Date = "2011",
                        Publisher = "Pinhan",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Johan Harstad",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Ay’da 172 Saat",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Berger",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Bir Fotoğrafı Anlamak",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Metis",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "John Berger",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Fotokopiler",
                        No = "",
                        Publish_Date = "2012",
                        Publisher = "Metis",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Berger",
                        Description = "",
                        Genre = "Söyleşi",
                        Name = "Görme Biçimleri",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Metis",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Berger - Yves Berger",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Uçuşan Etekler",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Metis",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jojo Moyes",
                        Description = "",
                        Genre = "Roman",
                        Name = "Senden Önce Ben",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Pegasus",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jorge Luis Borge",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kum Kitabı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Delifişek",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Güneşi Uyandıralım",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Çocuk",
                        Name = "Hayatın O Güzel Şarkısı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Çocuk",
                        Name = "Japon Sarayı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kardeşim Rüzgar Kardeşim Deniz",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kayığım Rosinha",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kırmızı Papağan",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Çocuk",
                        Name = "Kristal Yelkenli",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Şeker Portakalı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Jose Mauro De Vasconcelos",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yaban Muzu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Karl Marx",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Zincirlerimizden Başka Kaybedecek Neyimiz Var",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "",
                        Genre = "Öykü",
                        Name = "İçimizdeki Şeytan",
                        No = "",
                        Publish_Date = "2011",
                        Publisher = "Kaktüs",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "L.N. Tolstoy",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Ölüm Manifestosu",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "Kaktüs",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Laurent Seksik",
                        Description = "",
                        Genre = "Biografi",
                        Name = "Stefan Zweig’in Son Günleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Lugat 365",
                        Description = "",
                        Genre = "Lugat",
                        Name = "Bazı Kelimeler Çok Güzel",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Can",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Margit Schreiner",
                        Description = "",
                        Genre = "Roman",
                        Name = "Hayal Kırıklıkları Kitabı",
                        No = "",
                        Publish_Date = "2008",
                        Publisher = "Metis",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Michael Freeman",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Digital Görüntü Düzenleme & Özel Efektler",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Say",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Michael Freeman",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Fotoğrafçının Gözü",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Say",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Michael Freeman",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Fotoğrafçının Zihni",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Say",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Michael Freeman",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Fotoğrafta Pozlama ve Yaratıcılık",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Say",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Milan Kundera",
                        Description = "",
                        Genre = "Roman",
                        Name = "Varolmanın Dayanılmaz Hafifliği",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "N.H. Kleinbaum",
                        Description = "",
                        Genre = "Roman",
                        Name = "Ölü Ozanlar Derneği",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Bilge",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Neil Gaiman",
                        Description = "",
                        Genre = "Roman",
                        Name = "Amerikan Tanrıları",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Neil Gaiman",
                        Description = "",
                        Genre = "Roman",
                        Name = "Anansi Çocukları",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Neil Gaiman",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kırılgan Şeyler",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Neil Gaiman",
                        Description = "",
                        Genre = "Roman",
                        Name = "Mezarlık Kitabı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Neil Gaiman",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yolun Sonundaki Okyanus",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Nihad Siris",
                        Description = "",
                        Genre = "Roman",
                        Name = "Sessizlik ve Gürültü",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Jaguar",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Roman",
                        Name = "Ben Bir Ağacım",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Istanbul",
                        No = "",
                        Publish_Date = "2003",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kafamda Bir Tuhaflık",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kırmızı Saçlı Kadın",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Resimli İstanbul",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Anlatı",
                        Name = "Saf ve Düşünceli Romancı",
                        No = "",
                        Publish_Date = "2011",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Pamuk",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yeni Hayat",
                        No = "",
                        Publish_Date = "2011",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Orhan Veli",
                        Description = "",
                        Genre = "Şiir",
                        Name = "Garip",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Oscar Wilde",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Hayat Ciddiye Alınamayacak Kadar Önemlidir",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Paul Auster",
                        Description = "",
                        Genre = "Roman",
                        Name = "Leviathan",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Pierre Lotti",
                        Description = "",
                        Genre = "Roman",
                        Name = "İzlanda Balıkçısı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "R.J. Palacio",
                        Description = "",
                        Genre = "Roman",
                        Name = "Mucize",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Pegasus",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Fahrenheit 541",
                        No = "",
                        Publish_Date = "2012",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Karahindinbida Şarabı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Mars Yıllıkları",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Şimdi ve Daima",
                        No = "",
                        Publish_Date = "2010",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Sonbahar Ülkesi",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Ray Bradbury",
                        Description = "",
                        Genre = "Bilim Kurgu",
                        Name = "Uğursuz Birşey Geliyor Bu yana",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "İthaki",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Raymond Carver",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Fil",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Richard Bach",
                        Description = "",
                        Genre = "Roman",
                        Name = "Martı Jonathan Livingston",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Epsilon",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Roland Barthes",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Fotoğraf Üzerine Düşünceler",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "AltıKırkbeş",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sabahattin Ali",
                        Description = "",
                        Genre = "Roman",
                        Name = "İçimizdeki Şeytan",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sabahattin Ali",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kürk Mantolu Madonna",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sabahattin Ali",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kuyucaklı Yusuf",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sabahattin Ali",
                        Description = "",
                        Genre = "Roman",
                        Name = "Sırça Köşk",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Sabit Kalfagil",
                        Description = "",
                        Genre = "Fotoğraf",
                        Name = "Kompozisyon",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İlke Kitap",
                        RackNo = "4",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Samuel Buteer",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "Bilinen ve Bilinmeyen Tanrı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Altın Bilek",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Susanna Tamaro",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yüreğinin Götürdüğü Yere Git",
                        No = "",
                        Publish_Date = "1997",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Susie Hodge",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "50 Sanat Fikri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Domingo",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Thomas Mann",
                        Description = "",
                        Genre = "Roman",
                        Name = "Efendi İle Köpeği",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Thomas Mann",
                        Description = "",
                        Genre = "Roman",
                        Name = "Venedik’te Ölüm",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Tony Crilly",
                        Description = "",
                        Genre = "Araştırma",
                        Name = "50 Matematik Fikri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Domingo",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Uğur Yücel",
                        Description = "",
                        Genre = "Roman",
                        Name = "Yağmur Kesiği",
                        No = "",
                        Publish_Date = "2013",
                        Publisher = "Can",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltli"
                    },
                    new Book()
                    {
                        Author = "Vicente Blasco Ibanez",
                        Description = "",
                        Genre = "Tarih",
                        Name = "Fırtınadan Önce Şark",
                        No = "",
                        Publish_Date = "2009",
                        Publisher = "Türkiye İş Bankası",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Virginia Woolf",
                        Description = "",
                        Genre = "Aforizmalar",
                        Name = "Yalnızlık Ömür Boyu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Zeplin",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Wilhem Genazino",
                        Description = "",
                        Genre = "Roman",
                        Name = "Mutsuzluk Zamanlarında Mutluluk",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Ayrıntı",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Wilhem Genazino",
                        Description = "",
                        Genre = "Roman",
                        Name = "O gün için bir şemsiye",
                        No = "",
                        Publish_Date = "2014",
                        Publisher = "Jaguar",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "William Faulkner",
                        Description = "",
                        Genre = "Roman",
                        Name = "Döşeğimde Ölürken",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "İletişim",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Yaşar Kemal",
                        Description = "",
                        Genre = "Seçme",
                        Name = "Sevmek, Sevinmek, İyi Şeyler Üstüne",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Yusuf Atılgan",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Bütün Öyküleri",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Yapı Kredi Yayınları",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Brain K. Vaughan",
                        Description = "",
                        Genre = "Çizgi Roman",
                        Name = "Saga 2",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Marmara Çizgi",
                        RackNo = "1",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Kadınsız Erkekler",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Haşlanmış Harikalar Diyarı Ve Dünyanın Sonu",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Sınırın Güneyinde Güneşin Batısında",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Sahilde Kafka",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Zemberekkuşu’nun Güncesi",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "Renksiz Tsukuru Tazaki’nin Hac Yılları",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Haruki Murakami",
                        Description = "",
                        Genre = "Roman",
                        Name = "İmkansızın Şarkısı",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Dogan Kitap",
                        RackNo = "3",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "John Berger - Yücel Göktürk",
                        Description = "",
                        Genre = "Söyleşi",
                        Name = "İstanbuldan Gelen Telefon",
                        No = "",
                        Publish_Date = "2016",
                        Publisher = "Metis",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                    new Book()
                    {
                        Author = "Jose Saramago",
                        Description = "",
                        Genre = "Öykü",
                        Name = "Bilinmeyen Adanın Öyküsü",
                        No = "",
                        Publish_Date = "2015",
                        Publisher = "Kırmızı Kedi",
                        RackNo = "2",
                        Shelf = "Kitaplık 2",
                        Skin = "Ciltsiz"
                    },
                };

                //var shelfrepos = IoCManager.Container.Resolve<IShelfRepository>();
                //var authorrepos = IoCManager.Container.Resolve<IAuthorRepository>();
                //var genrerepos = IoCManager.Container.Resolve<IGenreRepository>();
                //var publisherrepos = IoCManager.Container.Resolve<IPublisherRepository>();
                //var rackrepos = IoCManager.Container.Resolve<IRackRepository>();
                //var seriesrepo = IoCManager.Container.Resolve<ISeriesRepository>();

                //var bookrepos = IoCManager.Container.Resolve<IBookRepository>();

                foreach (Book book in list)
                {
                    //var author = authorrepos.GetAll().FirstOrDefault(x => x.Name.Equals(book.Author));
                    var author = authorrepos.GetAuthorByName(book.Author);
                    //var genre = genrerepos.GetAll().FirstOrDefault(x => x.Genre.Equals(book.Genre));
                    var genre = genrerepos.GetGenreByName(book.Genre);
                    //var publisher = publisherrepos.GetAll().FirstOrDefault(x => x.Name.Contains(book.Publisher));
                    var publisher = publisherrepos.GetPublisherByName(book.Publisher);
                    //var series = seriesrepo.GetAll().FirstOrDefault(x => x.Name.Equals(book.Description));
                    var series = seriesrepo.GetSeriesbyName(book.Description);
                    //var rack = rackrepos.GetAll().FirstOrDefault(x => x.RackNumber == int.Parse(book.RackNo));
                    var rack = rackrepos.GetRackByRackNumber(int.Parse(book.RackNo));
                    //var shelf = shelfrepos.GetAll().FirstOrDefault(x => x.Name.Contains(book.Shelf));
                    var shelf = shelfrepos.GetShelfByName(book.Shelf);
                    

                    var ebook = new EBook()
                    {
                        Name = book.Name,
                        Author = author,
                        Genre = genre,
                        Publisher = publisher,
                        Serie = series ?? null,
                        Shelf = shelf,
                        CreatedDateTime = DateTime.Now,
                        No = book.No == "" ? null : book.No,
                        PublishDate = int.Parse(book.Publish_Date),
                        Rack = rack,
                        SkinType = book.Skin == "Ciltsiz" ? SkinType.Ciltli : SkinType.Ciltsiz
                    };

                    bookrepos.CreateEntity(ebook);
                }


                
            }
        }

        public string Name { get { return "00008_BookMigration"; } }
    }

    internal class Book
    {
        public string Shelf { get; set; }
        public string RackNo { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Publish_Date { get; set; }
        public string Genre { get; set; }
        public string No { get; set; }
        public string Skin { get; set; }
    }
}
    