using Library.BusinessLogic.DTO_s;

namespace Library.BusinessLogic.Services
{
    public interface IOrderService
    {
        Task<BorrowBookDto> AddAsync(BorrowBookDto borrowBookDto);
        Task DeleteAsync(int id);
        Task<BorrowBookDto> GetBooksByUserAsync(int userId);
        Task<List<BorrowBookDto>> GetBooksInHandAsync();
        public Task<List<BorrowBookDto>> GetBooksUserLate();
        public Task<BorrowBookDto> GetBorrowBookDto(int id);
    }
}