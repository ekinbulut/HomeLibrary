using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;
using Library.Data.Entities.Enums;

namespace Library.Data.Entities
{
    public class EBook : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual EAuthor Author { get; set; }
        public virtual EPublisher Publisher { get; set; }
        public virtual ESeries Serie { get; set; }
        public virtual int PublishDate { get; set; }
        public virtual EGenre Genre { get; set; }
        public virtual int? No { get; set; }
        public virtual SkinType SkinType { get; set; }
        public virtual EShelf Shelf { get; set; }
        public virtual ERack Rack { get; set; }
        public virtual ICollection<EUser> Users { get; set; }

        public virtual int AuthorId { get; set; }
        public virtual int PublisherId { get; set; }
        public virtual int? SeriesId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ShelfId { get; set; }
        public virtual int RackId { get; set; }
        //public virtual int UserId { get; set; }

        public EBook()
        {
            Users = new List<EUser>();
        }
    }
}
