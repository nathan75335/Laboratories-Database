using AutoMapper;
using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Exceptions;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;

namespace Library.BusinessLogic.Services;

public class OrderService : IOrderService
{
    private readonly IBorrowBookRepository _borrowBookRepository;
    private readonly IMapper _mapper;
    private readonly ISaveChangesRepository _saveChangesRepository;

    public OrderService(IBorrowBookRepository borrowBookRepository, IMapper mapper, ISaveChangesRepository saveChangesRepository)
    {
        _borrowBookRepository = borrowBookRepository;
        _mapper = mapper;
        _saveChangesRepository = saveChangesRepository;
    }

    public async Task<BorrowBookDto> AddAsync(BorrowBookDto borrowBookDto)
    {
        var book = _mapper.Map<BorrowBook>(borrowBookDto);
        book.GivenDate = DateTime.Now;

		_borrowBookRepository.Add(book);
        await _saveChangesRepository.SaveChangesAsync();

        return borrowBookDto;
    }

    public async Task DeleteAsync(int id)
    {
        var borrow = await _borrowBookRepository.GetBookAsync(id);

        if (borrow is null)
        {
            throw new NotFoundException("There is no such an order");
        }

        _borrowBookRepository.Delete(borrow);
        await _saveChangesRepository.SaveChangesAsync();
    }

    public async Task<BorrowBookDto> GetBooksByUserAsync(int userId)
    {
        var borrowList = await _borrowBookRepository.GetBooksByUserAsync(userId);

        return _mapper.Map<BorrowBookDto>(borrowList);
    }

    public async Task<List<BorrowBookDto>> GetBooksInHandAsync()
    {
        var borrowList = await _borrowBookRepository.GetBookInHandAsync();

        var listOfBookInHand = new List<BorrowBook>();

        foreach(var borrow in borrowList)
        {
            if(borrow.ReturnDate > DateTime.Now)
            {
                listOfBookInHand.Add(borrow);
            }
        }

        return _mapper.Map<List<BorrowBookDto>>(listOfBookInHand);
    }

    public async Task<List<BorrowBookDto>> GetBooksUserLate()
    {
        var borrowList = await _borrowBookRepository.GetBookInHandAsync();

        var listOfBookInHand = new List<BorrowBook>();

        foreach(var borrow in borrowList)
        {
            if(borrow.ReturnDate < DateTime.Now)
            {
                listOfBookInHand.Add(borrow);
            }
        }

        return _mapper.Map<List<BorrowBookDto>>(listOfBookInHand);
    }

    public async Task<BorrowBookDto> GetBorrowBookDto(int id)
    {
        var book = await _borrowBookRepository.GetBookAsync(id);

        return _mapper.Map<BorrowBookDto>(book);
    }
}
