using IdentityServer4.Extensions;
using Library.Api.Models;
using Library.BusinessLogic.Services;
using Library.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Roles =("Admin"))]
    public async Task<IActionResult> Index()
    {
        var users = await _accountService.GetUsersAsync();

        if (users.IsNullOrEmpty())
        {
            return View();
        }

        return View(users);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterModel register)
    {
        var user = new User()
        {
            Email = register.Email,
            LockoutEnabled = false,
            Sexe = register.Sexe,
            FirstName = register.FirstName,
            LastName = register.FirstName,
            UserName = register.UserName,
            EmailConfirmed = false,
            TwoFactorEnabled = false,
            AccessFailedCount = 0
        };

        var (resultOne, resultSecond) = await  _accountService.AddAsync(user, register.Password);

        if(resultOne && resultSecond)
        {
			return RedirectToAction("Index", "Home");
		}

        return View(register);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model)
    {
        await _accountService.LoginAsync(model.Email, model.Password);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _accountService.GetUserByIdAsync(id);

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(User user)
    {
        await _accountService.DeleteAsync(user);

        return RedirectToAction("Index");
    }
}