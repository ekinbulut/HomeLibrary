using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Entities
{
    public class EPublisher : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<ESeries> Series { get; set; }
        public virtual ICollection<EBook> Books { get; set; }

        public EPublisher()
        {
            Series = new List<ESeries>();
            Books = new List<EBook>();
        }
    }
}