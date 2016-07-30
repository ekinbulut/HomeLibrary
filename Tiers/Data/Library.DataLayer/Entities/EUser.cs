using System;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.DataLayer.Entities
{
    public class EUser : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual string Userame { get; set; }
        public virtual string Password { get; set; }
        public virtual string Occupation { get; set; }
        public virtual Gender Gender { get; set; } 
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual ERole ERole { get; set; }
        public virtual int RoleId { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
