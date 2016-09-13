using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Mappings
{
    public class EGenreConfiguration : EntityTypeConfigurationBase<EGenre,int>
    {
        public EGenreConfiguration(): base("Genre")
        {
            Property(x => x.Genre).IsRequired().HasMaxLength(35);
        }
    }
}
