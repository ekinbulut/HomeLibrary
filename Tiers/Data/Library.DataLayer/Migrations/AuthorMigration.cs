using System;
using System.Linq;
using Library.Data.Entities;
using Library.Data.Repositories.Authors;
using SenseFramework.Data.EntityFramework.DataMigrations;
using SenseFramework.Data.EntityFramework.Entities;
using SenseFramework.Data.EntityFramework.Repositories.Migration;

namespace Library.Data.Migrations
{
    public class AuthorMigration : IDataMigration
    {
        private readonly IMigrationRepository _migrationrepo;
        private readonly IAuthorRepository _authorrepos;

        public AuthorMigration(IMigrationRepository migrationrepo, IAuthorRepository authorrepos)
        {
            this._migrationrepo = migrationrepo;
            this._authorrepos = authorrepos;
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

                //var authorrepos = IoCManager.Container.Resolve<IAuthorRepository>();

                _authorrepos.CreateEntity(new EAuthor() { Name = "Aiskhylos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Aisopos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Aleksander Sergeyeviç Puşkin", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Alexandre Dumas", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Alfred De Musset", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Anton Pavloviç Çehov", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Baki", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Calderon De La Barca", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Carlo Goldini", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Charles Baudelaire", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Cicero", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Daniel Defoe", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Denis Diderot", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "E.T.A. Hoffman", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Edgar Allan Poe", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Edib Ahmed Yükneki", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Emile Zola", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Emily Dickinson", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Euripides", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Friedrich Nietzsche", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Fyodor M. Dostoyevski", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Galileo Galilei", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "George Eliot", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Giacomo Leopardi", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Gustave Flaubert", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Guy De Maupassant", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Hayyam", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Heinrich Von Kleist", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Henri Bergson", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Henry James", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Herodas", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Hippokrates", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Homeros", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Honore De Balzac", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "İbn Kalanisi", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "İsa Öztürk", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "İvan A. Gonçarov", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ivan Sergeyeviç Turgenyev", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jane Austen", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Johann W. Von Goethe", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jonathan Swift", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Katherine Mansfield", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Kolektif", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Kristof Kolomb", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ksenophon", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "L.N. Tolstoy", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "M.Y. Lermantov", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Mark Twain", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Mevlana", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Michelangelo", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Miguel De Cervantes", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Moliere", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Montesquieu", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Nikolay Vasilyeviç Gogol", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Novalis", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Platon", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Plutarkhos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Prokopios", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sophokles", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sun Zi", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Tsunetomo Yamamoto", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Valenciennes", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Vicente Blasco Ibanez", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Victor Hugo", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "William Shakespeare", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Yusuf Has Hacib", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Dionysios Byzantios", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Herman Melville", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "James Joyce", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Karl R. Popper", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Leonardo Da Vinci", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Mihail Yuryeviç Lermontov", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Anthony Burgess", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Bernard Shaw", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Carson McCullers", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "F.Scott Fitzgerald", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Franz Kafka", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Giovanni Papini", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Halil Cibran", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jack London", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "John Dos Passos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Joseph Conrad", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Maksim Gorki", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Miguel De Unamuno", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Mihail Bulgakov", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Pablo Neruda", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Paul Celan", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Rabindranath Tagore", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Rainer Maria Luke", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Robert Graves", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Robert Louis Stevenson", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sir Arthur Conan Doyle", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sir Athur Conan Doyle", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Stefan Zweig", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Virginia Woolf", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "William Golding", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Adrian Furnham", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Albert Camus", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Aldous Huxley", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Aleksandros Papadiamantis", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Alessandro Baricco", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Antoine de Saint-Exupery", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Apostolos Doksiadis", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Arkadi - Boris Strugatski", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Arthur C. Clarke", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Barış Bıçakçı", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ben Dupre", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ben Lerner", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Brain K. Vaughan", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Cahit Sıtkı Tarancı", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Carlos Maria Dominguez", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Carmine Gallo", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Cixin Liu", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Derleme", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Douglas Adams", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Emilie Kip Baker", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ernest Hemingway", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Fernando Pessoa", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Freud", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "George Frazer", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "George Owell", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Gündüz Vassaf", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "H.G. Wells", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Hagop Baronyan", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Harper Lee", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Haruki Murakami", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Irvin D. Yalom", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "J. D. Salinger", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "J.M.Coetzee", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "J.R.R. Tolkien", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jacob Abbott", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jean-Pierre Vernant", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Johan Harstad", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "John Berger", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "John Berger - Yves Berger", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jojo Moyes", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jorge Luis Borge", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jose Mauro De Vasconcelos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Karl Marx", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Laurent Seksik", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Lugat 365", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Margit Schreiner", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Michael Freeman", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Milan Kundera", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "N.H. Kleinbaum", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Neil Gaiman", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Nihad Siris", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Orhan Pamuk", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Orhan Veli", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Oscar Wilde", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Paul Auster", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Pierre Lotti", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "R.J. Palacio", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Ray Bradbury", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Raymond Carver", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Richard Bach", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Roland Barthes", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sabahattin Ali", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Sabit Kalfagil", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Samuel Buteer", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Susanna Tamaro", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Susie Hodge", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Thomas Mann", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Tony Crilly", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Uğur Yücel", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Wilhem Genazino", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "William Faulkner", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Yaşar Kemal", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Yusuf Atılgan", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Herodotos", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Montaigne", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "John Berger - Yücel Göktürk", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Jose Saramago", CreatedDateTime = DateTime.Now });
                _authorrepos.CreateEntity(new EAuthor() { Name = "Louis-Ferdinand Celine", CreatedDateTime = DateTime.Now });
            }
        }

        public string Name { get { return "00007_AuthorMigration"; } }
    }
}
