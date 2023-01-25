using Library.BusinessLogic.DTO_s;
using Library.DataAccess.Models;

namespace Library.BusinessLogic.Services;

public interface IBookService
{
    public Task<BookDto> AddAsync(BookDto bookDto);
    public Task<BookDto> UpdateAsync(BookDto bookDto);
    public Task<BookDto> DeleteAsync(BookDto bookDto);
    public Task<List<BookDto>> GetBooksAsync();

    public Task<BookDto> GetBookByIdAsync(int id);
}
