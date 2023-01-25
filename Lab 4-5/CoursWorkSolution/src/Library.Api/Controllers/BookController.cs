using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Services;
using Library.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Api.Project.Controllers;

[Authorize(Roles = ("Admin"))]
public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IGenreRepository _genreReposiory;
    private readonly IEditionHouseService _editionHouseService;

    public BookController(IBookService bookService, IGenreRepository genreReposiory, IEditionHouseService editionHouseService)
    {
        _bookService = bookService;
        _genreReposiory = genreReposiory;
        _editionHouseService = editionHouseService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _bookService.GetBooksAsync();
        
        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.EditionHouses = await _editionHouseService.GetEditionHousesAsync();
        ViewBag.Genres = await _genreReposiory.GetGenresAsync();

        return View();
    }

	[HttpPost]
	public async Task<IActionResult> Create(BookDto book)
	{
        await _bookService.AddAsync(book);

		return RedirectToAction("Index");
	}

	[HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

		ViewBag.EditionHouses = await _editionHouseService.GetEditionHousesAsync();
		ViewBag.Genres = await _genreReposiory.GetGenresAsync();

		return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BookDto bookDto)
    {
        var book = await _bookService.UpdateAsync(bookDto);

        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

		ViewBag.EditionHouses = await _editionHouseService.GetEditionHousesAsync();
		ViewBag.Genres = await _genreReposiory.GetGenresAsync();

		return View(book);
    }

	[HttpPost]
	public async Task<IActionResult> Delete(BookDto bookDto)
	{
		var book = await _bookService.DeleteAsync(bookDto);

		return RedirectToAction("Index");
	}


	[HttpGet]
	[AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        return View(book);
    }
}
