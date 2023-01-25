using AutoMapper;
using IdentityServer4.Extensions;
using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Exceptions;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;

namespace Library.BusinessLogic.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ISaveChangesRepository _saveChangesRepository;

    public BookService(IBookRepository bookRepository, IMapper mapper, ISaveChangesRepository saveChangesRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _saveChangesRepository = saveChangesRepository;
    }

    public async Task<BookDto> AddAsync(BookDto bookDto)
    {
        var bookLooked = await _bookRepository.GetBookAsync(bookDto.Name);

        if (bookLooked is not null)
        {
            throw new AlreadyExistException("This book already exist");
        }

        var book = _mapper.Map<Book>(bookDto);

		_bookRepository.Add(book);
        await _saveChangesRepository.SaveChangesAsync();

        return bookDto;
    }

    public async Task<BookDto> UpdateAsync(BookDto bookDto)
    {
        var bookLooked = await _bookRepository.GetBookAsync(bookDto.Id);

        if (bookLooked is null)
        {
            throw new NotFoundException("This book does not exist");
        }

        bookLooked = _mapper.Map<Book>(bookDto);
        _bookRepository.Update(bookLooked);
        await _saveChangesRepository.SaveChangesAsync();

        return bookDto;
    }

    public async Task<BookDto> DeleteAsync(BookDto bookDto)
    {
        var bookLooked = await _bookRepository.GetBookAsync(bookDto.Id);

        if (bookLooked is null)
        {
            throw new NotFoundException("This book does not exist");
        }
        
        _bookRepository.Delete(bookLooked);
        await _saveChangesRepository.SaveChangesAsync();

        return bookDto;
    }

    public async Task<List<BookDto>> GetBooksAsync()
    {
        var list = await _bookRepository.GetBooksAsync();

        return _mapper.Map<List<BookDto>>(list);
    }

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);
        
        if(book is null)
        {
            throw new NotFoundException("The book was not found");
        }

        return _mapper.Map<BookDto>(book);
    }
}
