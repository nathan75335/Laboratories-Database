using IdentityServer4.Extensions;
using Library.BusinessLogic.Exceptions;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Library.BusinessLogic.Services;

public class AccountService : IAccountService
{
   private readonly UserManager<User> _userManager;
   private readonly SignInManager<User> _signInManager; 
   private readonly ISaveChangesRepository _changesRepository;
   private readonly IWorkerRepository _workerRepository;

    public AccountService(UserManager<User> userManager, IWorkerRepository workerRepository,
       SignInManager<User> signInManager,
       ISaveChangesRepository changesRepository)
    {
        _userManager = userManager;
        _workerRepository = workerRepository;
        _signInManager = signInManager;
        _changesRepository = changesRepository;
      
    }

    public async Task<(bool, bool)> AddAsync(User user, string password)
   {
      using (_userManager)
      {
         var userLooked = await _userManager.FindByEmailAsync(user.Email);

         if (userLooked is not null)
         {
            throw new AlreadyExistException("This user already exists");
         }

         user.AccessFailedCount = 0;
         user.EmailConfirmed = false;
         user.LockoutEnabled =  false;
         user.TwoFactorEnabled = false;
         var result = await _userManager.CreateAsync(user, password);

         var roleResult = await _userManager.AddToRoleAsync(user, new Role("User").Name);

         return (result.Succeeded, roleResult.Succeeded);
      }
   }

   public async Task AddAsync(Worker worker)
   {
      var workerLooked = await _workerRepository.GetWorkerAsync(worker.Name);

      if (workerLooked is not null)
      {
         throw new AlreadyExistException("The worker already exists");
      }

      _workerRepository.Add(worker);

      await _changesRepository.SaveChangesAsync();
   }

   public async Task DeleteAsync(User user)
   {
      using (_userManager)
      {
         var userLooekd = await _userManager.FindByIdAsync(user.Id.ToString());

         if (userLooekd is null)
         {
            throw new NotFoundException("The user was not found");
         }

         await _userManager.DeleteAsync(userLooekd);
      }
   }

   public async Task<User> LoginAsync(string email, string password)
   {
      var user = await _userManager.FindByEmailAsync(email);

      if (user is null)
      {
         throw new NotFoundException("Check your password and email");
      }

      var isValid = await _userManager.CheckPasswordAsync(user, password);

      if (isValid)
      {
         await _signInManager.SignInAsync(user, true);
      }
      else
      {
            throw new NotFoundException("The credential were not correct");
      }

      return user;
   }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

   public async Task UpdateAsync(User user)
   {
      using (_userManager)
      {
         var userLooked = await _userManager.GetUserIdAsync(user);

         if (userLooked is null)
         {
            throw new NotFoundException("The user was not found");
         }

         await _userManager.UpdateAsync(user);
      }
   }

   public async Task DeleteWorker(Worker worker)
   {
      var workerLooked = await _workerRepository.GetWorkerAsync(worker.Id);

      if (workerLooked is null)
      {
         throw new NotFoundException("The user was not found");
      }
      
      _workerRepository.Delete(worker);

      await _changesRepository.SaveChangesAsync();
   }

    public async Task<List<User>> GetUsersAsync()
    {
        var list = await _userManager.GetUsersInRoleAsync("User");

        var userList = list.ToList();

        if (userList.IsNullOrEmpty())
        {
            throw new NotFoundException("The user was not found");
        }

        return userList;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if(user is null)
        {
            throw new NotFoundException("The user was not found");
        }

        return user;
    }

    public async Task<Worker> GetWorkerByIdAsync(int id)
    {
        var worker = await _workerRepository.GetWorkerAsync(id);

        if(worker is null)
        {
            throw new NotFoundException("The worker was not found");
        }

        return worker;
    }

    public async Task<List<Worker>> GetWorkersAsync()
    {
        var list = await _workerRepository.GetWorkersAsync();

        return list;
    }

    public async Task UpdateWorkerAsync(Worker worker)
    {
		var workerLooked = await _workerRepository.GetWorkerAsync(worker.Id);

		if (workerLooked is null)
		{
			throw new NotFoundException("The user was not found");
		}

		_workerRepository.Update(worker);

		await _changesRepository.SaveChangesAsync();
	}
}
