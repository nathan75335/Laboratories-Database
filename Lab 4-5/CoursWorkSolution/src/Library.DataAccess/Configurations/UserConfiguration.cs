using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Email).IsRequired();
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.PasswordHash).IsRequired();
            builder.Property(i => i.PhoneNumber).IsRequired(false);
            
            builder.ToTable("Users");
        }
    }
}
