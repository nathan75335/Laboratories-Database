using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.Api.Models;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Api.Controllers
{
	public class BorrowBookController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly IBookService _bookService;
		private readonly IAccountService _accountService;
		private readonly IGenreRepository _genreRepository;

		public BorrowBookController(IOrderService orderService, IBookService bookService, IAccountService accountService, IGenreRepository genreRepository)
		{
			_orderService = orderService;
			_bookService = bookService;
			_accountService = accountService;
			_genreRepository = genreRepository;
		}

		[HttpGet]
		[Authorize(Roles =("User,Admin"))]
		public async Task<IActionResult> Borrow(int id)
		{
			ViewBag.BookId = id;
			ViewBag.Workers = await _accountService.GetWorkersAsync();

			return View();
		}

		[HttpPost]
		[Authorize(Roles = ("User,Admin"))]
		public async Task<IActionResult> Borrow(BorrowBookDto borrow)
		{
			borrow.UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			borrow.BookId = borrow.Id;
			borrow.Id = 0;

			await _orderService.AddAsync(borrow);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Index(int? genre, string? name)
		{
			var list = await _orderService.GetBooksInHandAsync();

			if (genre != 0 && genre is not null)
			{
				list = list.Where(i => i.Book.Genre.Id == genre).ToList();
			}

			if (!string.IsNullOrEmpty(name))
			{
				list = list.Where(i => i.Book.Author.Contains(name)).ToList();
			}

			List<Genre> genres = await _genreRepository.GetGenresAsync();
			
			genres.Insert(0, new Genre() {Name = "All", Id = 0});

			BorrowModelView borrowModelView = new BorrowModelView()
			{
				Books = list,
				Genres = new SelectList(genres, "Id", "Name", genre)
			};

			return View(borrowModelView);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			await _orderService.DeleteAsync(id);

			return RedirectToAction("Index");
		}
		
		[HttpGet]
		public async Task<IActionResult> BookUserLate()
		{
			var list =  await _orderService.GetBooksInHandAsync();

			var users = list.Select(i => i.User).ToList();

			return View(users);
		}
	}
}
