namespace Library.DataAccess.Repositories;

public class SaveChangesRepository : ISaveChangesRepository
{
    private readonly BookContext _bookContext;

    public SaveChangesRepository(BookContext bookContext)
    {
        _bookContext = bookContext;
    }

    public Task SaveChangesAsync()
    {
        return _bookContext.SaveChangesAsync();
    }
}
