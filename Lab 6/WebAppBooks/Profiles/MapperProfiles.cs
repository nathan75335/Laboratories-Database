using AutoMapper;
using BusinessLogic.DTO_s;
using DataAccess.Models;

namespace WebAppBooks.Profiles
{
    /// <summary>
    /// The configuration of all the mapping profiles in the application
    /// </summary>
    public class MapperProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MapperProfiles"/>
        /// </summary>
        public MapperProfiles()
        {
            CreateMap<GenreDto, Genre>()
                .ForMember(dest => dest.Books, source => source.Ignore())
                .ReverseMap();
            
            CreateMap<BookDto, Book>()
                .ReverseMap();
        }
    }
}
