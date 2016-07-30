using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.DataLayer.Entities
{
    public class EGenre : Entity<int>
    {
        public virtual string Genre { get; set; }

        public virtual ICollection<EBook> Books { get; set; }

        public EGenre()
        {
            Books = new List<EBook>();
        }
    }
}