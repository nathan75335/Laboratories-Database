using Library.BusinessLogic.DTO_s;

namespace Library.BusinessLogic.Services;

public interface IEditionHouseService
{
    public Task<EditionHouseDto> AddAsync(EditionHouseDto editionHouseDto);
    public Task<EditionHouseDto> UpdateAsync(EditionHouseDto editionHouseDto);
    public Task<EditionHouseDto> DeleteAsync(EditionHouseDto editionHouseDto);
    public Task<List<EditionHouseDto>> GetEditionHousesAsync();
	Task<EditionHouseDto> GetEditionHouseById(int id);
}
