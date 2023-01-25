using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations;

public class BookBorrowConfiguration : IEntityTypeConfiguration<BorrowBook>
{
    public void Configure(EntityTypeBuilder<BorrowBook> builder)
    {
        builder.HasKey(i => i.Id);
        
        builder.Property(i => i.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne<Book>(i => i.Book)
            .WithMany(i => i.BorrowBooks);
        builder.HasOne<Worker>(i => i.Worker)
            .WithMany(i => i.BorrowBooks);
        builder.HasOne<User>(i => i.User)
            .WithMany(i => i.BorrowBooks);

        builder.ToTable("BorrowBooks");
    }
}
