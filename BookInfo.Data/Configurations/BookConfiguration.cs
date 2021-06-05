using BookInfo.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookInfo.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Genre).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Abstract);
            builder.Property(m => m.Page).IsRequired();
            builder.ToTable("Books");
        }
    }
}
