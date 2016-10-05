﻿using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Book.TypeMappings
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
            Property(x => x.No).HasMaxLength(15).IsOptional();
            HasRequired(x => x.Shelf).WithMany(x=>x.Books).HasForeignKey(x=>x.ShelfId);
            HasRequired(x => x.Rack).WithMany(x=>x.Books).HasForeignKey(x=>x.RackId);
            HasOptional(x=>x.Serie).WithMany(x=>x.Books).HasForeignKey(x=>x.SeriesId);

        }
    }
}