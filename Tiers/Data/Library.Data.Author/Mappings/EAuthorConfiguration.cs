using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Author.Mappings
{
    public class EAuthorConfiguration : EntityTypeConfigurationBase<EAuthor,int>
    {
        public EAuthorConfiguration():base("Author")
        {
            Property(x => x.Name).HasMaxLength(150).IsRequired();
        }
    }
}
