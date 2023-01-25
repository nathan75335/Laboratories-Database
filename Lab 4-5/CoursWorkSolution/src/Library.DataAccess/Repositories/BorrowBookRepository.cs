using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class BorrowBookRepository : IBorrowBookRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<BorrowBook> _borrowBooks;

    public BorrowBookRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _borrowBooks = _bookContext.Set<BorrowBook>();
    }

    public void Add(BorrowBook book)
    {
        _borrowBooks.Add(book);
    }

    public void Update(BorrowBook book)
    {
        _borrowBooks.Update(book);
    }

    public void Delete(BorrowBook book)
    {
        _borrowBooks.Remove(book);
    }
    
    public Task<BorrowBook?> GetBookAsync(int id)
    {
        return _borrowBooks
            .Include(i => i.Book)
            .Include(i => i.User)
            .Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }
    
    public Task<List<BorrowBook>> GetBooksByUserAsync(int userId)
    {
        return _borrowBooks.Where(i => i.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<List<BorrowBook>> GetBookInHandAsync()
    {
        return _borrowBooks
            .Include(i => i.Worker)
            .Include(i => i.Book)
            .ThenInclude(i => i.Genre)
            .Include(i => i.User)
            .AsNoTracking()
            .ToListAsync();
    }
}
