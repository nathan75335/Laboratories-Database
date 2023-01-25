using AutoMapper;
using IdentityServer4.Extensions;
using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Exceptions;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;

namespace Library.BusinessLogic.Services;

public class EditionHouseService : IEditionHouseService
{
    private readonly IEditionHouseRepository _editionHouseRepository;
    private readonly ISaveChangesRepository _saveChangesRepository;
    private readonly IMapper _mapper;

    public EditionHouseService(IEditionHouseRepository editionHouseRepository, IMapper mapper, ISaveChangesRepository saveChangesRepository)
    {
        _mapper = mapper;
        _saveChangesRepository = saveChangesRepository;
        _editionHouseRepository = editionHouseRepository;
    }

    public async Task<EditionHouseDto> AddAsync(EditionHouseDto editionHouseDto)
    {
        var editionHouseLooked = await _editionHouseRepository.GetEditionHouseAsync(editionHouseDto.Name);

        if (editionHouseLooked is not null)
        {
            throw new AlreadyExistException("This edition house already exist");
        }
        
        _editionHouseRepository.Add(_mapper.Map<EditionHouse>(editionHouseDto));
        await _saveChangesRepository.SaveChangesAsync();

        return editionHouseDto;
    }

    public async Task<EditionHouseDto> UpdateAsync(EditionHouseDto editionHouseDto)
    {
        var editionHouseLooked = await _editionHouseRepository.GetEditionHouseAsync(editionHouseDto.Id);

        if (editionHouseDto is null)
        {
            throw new NotFoundException("This edition house does not exist");
        }

        editionHouseLooked.Name = editionHouseDto.Name;
        editionHouseLooked.City = editionHouseDto.City;
        editionHouseLooked.Adress = editionHouseDto.Adress;
        
        _editionHouseRepository.Update(_mapper.Map<EditionHouse>(editionHouseDto));
        await _saveChangesRepository.SaveChangesAsync();

        return editionHouseDto;
    }

    public async Task<EditionHouseDto> DeleteAsync(EditionHouseDto editionHouseDto)
    {
        var editionHouseLooked = await _editionHouseRepository.GetEditionHouseAsync(editionHouseDto.Id);

        if (editionHouseDto is null)
        {
            throw new NotFoundException("This edition house does not exist");
        }
        
        _editionHouseRepository.Delete(_mapper.Map<EditionHouse>(editionHouseDto));
        await _saveChangesRepository.SaveChangesAsync();

        return editionHouseDto;
    }

    public async Task<List<EditionHouseDto>> GetEditionHousesAsync()
    {
        var list = await _editionHouseRepository.GetEditionHousesAsync();

        if (list.IsNullOrEmpty())
        {
            throw new NotFoundException("The edition Houses were not found");
        }

        return _mapper.Map<List<EditionHouseDto>>(list);
    }

    public async Task<EditionHouseDto> GetEditionHouseById(int id)
    {
        var edition = await _editionHouseRepository.GetEditionHouseAsync(id);

        if(edition is null)
        {
			throw new NotFoundException("The edition House were not found");
		}

        return _mapper.Map<EditionHouseDto>(edition);
    }
}
