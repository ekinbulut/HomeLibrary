using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class EAuthorConfiguration : EntityTypeConfigurationBase<EAuthor,int>
    {
        public EAuthorConfiguration():base("Author")
        {
            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}
