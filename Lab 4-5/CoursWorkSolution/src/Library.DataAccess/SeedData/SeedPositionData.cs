using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.SeedData;

public class SeedPositionData
{
    private readonly BookContext _bookContext;
    private readonly DbSet<Position> _positions;

    public List<Position> Positions = new List<Position>()
    {
        new Position()
        {
            Name = "Comptability"
        },
        new Position()
        {
            Name = "Guardian"
        },
        new Position()
        {
            Name = "Library-Service"
        }
    };

    public SeedPositionData(BookContext bookContext)
    {
        _bookContext = bookContext;
        _positions = _bookContext.Set<Position>();
    }

    public SeedPositionData()
    {

    }

    public void SeedPositions()
    {
        if (!_positions.Any())
        {
            _positions.AddRange(Positions);
            _bookContext.SaveChanges();
        }
    }
}
