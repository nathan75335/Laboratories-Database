using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IPositionRepository
{
    public Task<List<Position>> GetPositionsAsync();
}
