using Library.Data.Entities;
using SenseFramework.Data.EntityFramework;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Books.Mappings
{
    public class EBookConfiguration : EntityTypeConfigurationBase<EBook,int>
    {
        public EBookConfiguration():base("book")
        {
            Property(x => x.Name).HasMaxLength(int.MaxValue).IsRequired();

            HasRequired(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            HasRequired(x => x.Publisher).WithMany(x=>x.Books).HasForeignKey(x=>x.PublisherId);
            Property(x => x.PublishDate).IsRequired();
            HasRequired(x => x.Genre).WithMany(x=>x.Books).HasForeignKey(x=>x.GenreId);
            Property(x => x.No).IsOptional();
            HasRequired(x => x.Shelf).WithMany(x=>x.Books).HasForeignKey(x=>x.ShelfId);
            HasRequired(x => x.Rack).WithMany(x=>x.Books).HasForeignKey(x=>x.RackId);
            HasOptional(x=>x.Serie).WithMany(x=>x.Books).HasForeignKey(x=>x.SeriesId);

            HasMany(x => x.Users).WithMany(x => x.Books).Map(tbl =>
            {
                tbl.MapLeftKey("BookIdFk");
                tbl.MapRightKey("UserIdFk");
                tbl.ToTable(Schema.Prefix + "BOOKS_USERS");
            });

        }
    }
}
