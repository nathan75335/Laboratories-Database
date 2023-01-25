using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class PositionRepository : IPositionRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<Position> _positions;

    public PositionRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _positions = _bookContext.Set<Position>();
    }

    public Task<List<Position>> GetPositionsAsync()
    {
        return _positions.AsNoTracking().ToListAsync();
    }
}
