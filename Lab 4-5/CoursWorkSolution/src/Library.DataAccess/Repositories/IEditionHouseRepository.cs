using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories;

public interface IEditionHouseRepository
{
    /// <summary>
    /// Function to add an edition house to the databases
    /// </summary>
    /// <param name="house">The edtion house</param>
    public void Add(EditionHouse house);
    public void Update(EditionHouse house);
    public void Delete(EditionHouse house);
    public Task<EditionHouse?> GetEditionHouseAsync(int id);
    public Task<EditionHouse?> GetEditionHouseAsync(string name);

    public Task<List<EditionHouse>> GetEditionHousesAsync();

}
