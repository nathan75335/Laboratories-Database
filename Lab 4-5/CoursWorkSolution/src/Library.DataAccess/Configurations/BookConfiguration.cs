using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();
        builder.Property(i => i.Price)
            .HasColumnType("money");
        builder.Property(i => i.Price)
            .HasPrecision(3);
        builder.HasOne<EditionHouse>(i => i.EditionHouse)
            .WithMany(i => i.Books);
        builder.HasOne<Genre>(i => i.Genre)
            .WithMany(i => i.Books);
        
        builder.ToTable("Books");
    }
}
