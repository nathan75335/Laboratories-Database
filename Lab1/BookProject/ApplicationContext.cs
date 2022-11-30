using Microsoft.EntityFrameworkCore;

namespace BookProject
{
    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(i => i.Id)
                 .ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Laboratoy;Trusted_Connection=True;");
            }
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<EditionHouse> EditionHouses { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
