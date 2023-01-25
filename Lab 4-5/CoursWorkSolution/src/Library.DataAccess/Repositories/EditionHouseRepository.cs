using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories;

public class EditionHouseRepository : IEditionHouseRepository
{
    private readonly BookContext _bookContext;
    private readonly DbSet<EditionHouse> _editionHouses;
    
    /// <summary>
    /// Initializes a new instance of <see cref="EditionHouseRepository"/>
    /// </summary>
    /// <param name="bookContext">The book context</param>
    public EditionHouseRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
        _editionHouses = _bookContext.Set<EditionHouse>();
    }
    
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="house">The edition house</param>
    public void Add(EditionHouse house)
    {
        _editionHouses.Add(house);
    }

    public void Update(EditionHouse house)
    {
        _editionHouses.Update(house);
    }

    public void Delete(EditionHouse house)
    {
        _editionHouses.Remove(house);
    }

    public Task<EditionHouse?> GetEditionHouseAsync(int id)
    {
        return _editionHouses.Where(i => i.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public Task<EditionHouse?> GetEditionHouseAsync(string name)
    {
        return _editionHouses.Where(i => i.Name == name)
            .AsNoTracking().FirstOrDefaultAsync();
    }

    public Task<List<EditionHouse>> GetEditionHousesAsync()
    {
        return _editionHouses.ToListAsync();
    }
}
