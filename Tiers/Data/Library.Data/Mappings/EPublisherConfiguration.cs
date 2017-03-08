using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Mappings
{
    public class EPublisherConfiguration : EntityTypeConfigurationBase<EPublisher,int>
    {
        public EPublisherConfiguration():base("Publisher")
        {
            Property(x => x.Name).HasMaxLength(75).IsRequired();
        }
    }
}