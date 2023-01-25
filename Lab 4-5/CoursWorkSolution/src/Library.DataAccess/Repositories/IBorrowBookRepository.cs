using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IBorrowBookRepository
{
    public void Add(BorrowBook book);
    public void Update(BorrowBook book);
    public void Delete(BorrowBook book);
    public Task<List<BorrowBook>> GetBooksByUserAsync(int userId);
    public Task<List<BorrowBook>> GetBookInHandAsync();
    public Task<BorrowBook?> GetBookAsync(int id);
}
