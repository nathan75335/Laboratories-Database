using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IBookRepository
{
   public void Add(Book book);
   public void Update(Book book);
   public Task<Book?> GetBookAsync(int id);
   public Task<Book?> GetBookAsync(string name);
   public Task<List<Book>?> GetBooksAsync();
   public void Delete(Book book);
}
