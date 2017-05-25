using System;
using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Entities
{
    public class EUser : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Occupation { get; set; }
        public virtual Gender Gender { get; set; } 
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual ERole ERole { get; set; }
        public virtual int RoleId { get; set; }

        public virtual ICollection<EBook> Books { get; set; }

        public EUser()
        {
            Books = new List<EBook>();
        } 
    }

    public enum Gender
    {
        Male,
        Female
    }
}
