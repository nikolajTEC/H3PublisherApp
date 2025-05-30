using AutoMapper;
using Core.DTO;
using REST_API.Objects;

namespace REST_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Authors, AuthorDTO>();
            CreateMap<Books, BookDTO>();
            CreateMap<Covers, CoverDTO>()
                .ForMember(dest => dest.Artists, opt => opt.MapFrom(src =>
                    src.ArtistCovers.Select(ac => ac.Artist)));

            CreateMap<Artists, ArtistDTO>();

            // Optional: DTO to Entity (for creating/updating)
            CreateMap<AuthorDTO, Authors>();
            CreateMap<BookDTO, Books>();
            CreateMap<CoverDTO, Covers>();
            CreateMap<ArtistDTO, Artists>();
        }
    }
}
