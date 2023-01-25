using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Api.Models;
using Library.BusinessLogic.Services;

namespace Library.Api.Controllers;

public class HomeController : Controller
{
    private readonly IBookService _service;
    public HomeController(IBookService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _service.GetBooksAsync();

        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}