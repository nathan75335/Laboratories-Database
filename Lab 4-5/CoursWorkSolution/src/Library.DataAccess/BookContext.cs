using Library.DataAccess.Configurations;
using Library.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess;

public class BookContext : IdentityDbContext<User, Role, int>
{
    /// <summary>
    /// Initializes a new instance of <see cref="BookContext"/>
    /// </summary>
    /// <param name="options">The options</param>
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
                    
    }
    
    /// <summary>
    /// Configuring the database on creating 
    /// </summary>
    /// <param name="builder">The builder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}
