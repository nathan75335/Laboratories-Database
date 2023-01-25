using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<Book> _books;

    public BookRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _books = _bookContext.Set<Book>();
    }

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public void Update(Book book)
    {
        _books.Update(book);
    }

    public void Delete(Book book)
    {
        _books.Remove(book);
    }

    public Task<Book?> GetBookAsync(int id)
    {
        return _books.Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public Task<Book?> GetBookAsync(string name)
    {
        return _books.Include(i => i.Genre)
            .Include(i => i.EditionHouse)
            .Where(i => i.Name == name)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public Task<List<Book>?> GetBooksAsync()
    {
        return _books.Include(i => i.Genre).Include(i => i.EditionHouse).AsNoTracking().ToListAsync();
    }
}
