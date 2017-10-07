using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Entities
{
    public class EAuthor : Entity<int>
    {
        public virtual string Name { get; set; }

        public virtual ICollection<EBook> Books { get; set; }

        public EAuthor()
        {
            Books = new List<EBook>();
        }
    }
}