using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IGenreRepository
{
   public Task<List<Genre>> GetGenresAsync();
}
