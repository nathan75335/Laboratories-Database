using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<Genre> _genres;

    /// <summary>
    /// Initializes a new instance of <see cref="GenreRepository"/>
    /// </summary>
    /// <param name="bookContext">The book context</param>
    public GenreRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _genres = _bookContext.Set<Genre>();
    }

    public Task<List<Genre>> GetGenresAsync()
    {
        return _genres.ToListAsync();
    }
}
