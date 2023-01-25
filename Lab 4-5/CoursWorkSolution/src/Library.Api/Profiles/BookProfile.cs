using AutoMapper;
using Library.BusinessLogic.DTO_s;
using Library.DataAccess.Models;

namespace Library.Api.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<EditionHouseDto, EditionHouse>()
            .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
            .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
            .ForMember(dest => dest.Adress, source => source.MapFrom(source => source.Adress))
            .ForMember(dest => dest.City, source => source.MapFrom(source => source.City))
            .ReverseMap();

        CreateMap<BookDto, Book>()
            .ForMember(dest => dest.Id, source => source.MapFrom(source => source.Id))
            .ForMember(dest => dest.Name, source => source.MapFrom(source => source.Name))
            .ForMember(dest => dest.GenreId, source => source.MapFrom(source => source.GenreId))
            .ForMember(dest => dest.EditionHouseId, source => source.MapFrom(source => source.EditionHouseId))
            .ReverseMap();

        CreateMap<BorrowBookDto, BorrowBook>()
            .ReverseMap();
    }
}