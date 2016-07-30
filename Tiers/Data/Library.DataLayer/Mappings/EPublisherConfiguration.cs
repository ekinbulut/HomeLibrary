using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class EPublisherConfiguration : EntityTypeConfigurationBase<EPublisher,int>
    {
        public EPublisherConfiguration():base("Publisher")
        {
            Property(x => x.Name).HasMaxLength(75).IsRequired();
        }
    }
}