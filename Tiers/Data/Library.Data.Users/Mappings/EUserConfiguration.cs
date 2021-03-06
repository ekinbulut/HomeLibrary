﻿using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Users.Mappings
{
    public class EUserConfiguration : EntityTypeConfigurationBase<EUser,int>
    {
        public EUserConfiguration():base("USERS")
        {
            Property(x => x.Name).HasMaxLength(35).IsRequired();
            Property(x => x.UserName).HasMaxLength(35).IsRequired();
            Property(x => x.Password).HasMaxLength(35).IsRequired();
            Property(x => x.Occupation).HasMaxLength(100).IsRequired();
            Property(x => x.Gender);
            Property(x => x.LastLoginDate).IsOptional();
            Property(x => x.IsActive).IsOptional();

            HasRequired(x => x.ERole).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            
        }
    }
}
