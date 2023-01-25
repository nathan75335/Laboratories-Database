using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class WorkerRepository : IWorkerRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<Worker> _workers;

    public WorkerRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _workers = _bookContext.Set<Worker>();
    }
    
    public void Add(Worker worker)
    {
        _workers.Add(worker);
    }

    public void Update(Worker worker)
    {
        _workers.Update(worker);
    }

    public void Delete(Worker worker)
    {
        _workers.Remove(worker);
    }

    public Task<Worker?> GetWorkerAsync(int id)
    {
        return _workers.Include(i => i.Position).Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public Task<Worker?> GetWorkerAsync(string name)
    {
        return _workers.Include(i => i.Position).Where(i => i.Name == name)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public Task<List<Worker>> GetWorkersAsync()
    {
        return _workers.Include(i => i.Position).AsNoTracking().ToListAsync();
    }
}
