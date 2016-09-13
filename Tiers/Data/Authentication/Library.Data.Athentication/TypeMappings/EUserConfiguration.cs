using Library.Data.Athentication.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Athentication.TypeMappings
{
    public class EUserConfiguration : EntityTypeConfigurationBase<EUser,int>
    {
        public EUserConfiguration():base("USERS")
        {
            Property(x => x.Name).HasMaxLength(35).IsRequired();
            Property(x => x.Userame).HasMaxLength(35).IsRequired();
            Property(x => x.Password).HasMaxLength(35).IsRequired();
            Property(x => x.Occupation).HasMaxLength(100).IsRequired();
            Property(x => x.Gender);
            Property(x => x.LastLoginDate).IsOptional();
            Property(x => x.IsActive).IsOptional();

            HasRequired(x => x.ERole).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
        }
    }
}
