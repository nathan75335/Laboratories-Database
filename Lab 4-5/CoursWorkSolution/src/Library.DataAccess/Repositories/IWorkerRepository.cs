using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IWorkerRepository
{
   public void Add(Worker worker);
   public void Update(Worker worker);
   public void Delete(Worker worker);
   public Task<Worker?> GetWorkerAsync(int id);
   public Task<Worker?> GetWorkerAsync(string name);
   public Task<List<Worker>> GetWorkersAsync();
}