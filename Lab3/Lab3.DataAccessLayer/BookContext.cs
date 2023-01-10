using Lab3.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.DataAccessLayer
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<EditionHouse> EditionHouses { get; set;}

        public virtual DbSet<Genre> Genres { get; set; }
    }
}