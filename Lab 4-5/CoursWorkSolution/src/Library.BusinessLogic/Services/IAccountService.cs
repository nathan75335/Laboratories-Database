using Library.DataAccess.Models;

namespace Library.BusinessLogic.Services;

public interface IAccountService
{
    public Task<(bool, bool)> AddAsync(User user, string password);
    public Task AddAsync(Worker worker);
    Task DeleteAsync(User user);
    Task DeleteWorker(Worker worker);
    Task<User> GetUserByIdAsync(int id);
    Task<List<User>> GetUsersAsync();
    Task<List<Worker>> GetWorkersAsync();
    Task<Worker> GetWorkerByIdAsync(int id);
    public Task<User> LoginAsync(string email, string password);
    public Task LogoutAsync();
	Task UpdateWorkerAsync(Worker worker);
}
