using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.SeedData;

public class SeedGenresData
{
    public List<Genre> genres = new List<Genre>
    {
        new Genre()
        {
            Name = "Romance",
            Desctiption = "This is a romantic book"
        },
        new Genre()
        {
            Name = "Fiction",
            Desctiption = "This is a fiction book"
        }
    };

    private readonly BookContext _bookContext;
    private readonly DbSet<Genre> _genres;

    public SeedGenresData(BookContext bookContext)
    {
        _bookContext = bookContext;
        _genres = _bookContext.Set<Genre>();
    }

    public SeedGenresData()
    {
        
    }
    
    public void SeedGenre()
    {
        if (!_genres.Any())
        {
            _genres.AddRange(genres);
            _bookContext.SaveChanges();
        }
    }
}
