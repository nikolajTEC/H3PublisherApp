using AutoMapper;
using Core.DTO;
using REST_API.Objects;

namespace REST_API
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			// Artist mappings
			CreateMap<Artists, ArtistDTO>()
				.ReverseMap();

			// Author mappings
			CreateMap<Authors, AuthorDTO>()
				.ReverseMap();

			// Book mappings
			CreateMap<Books, BookDTO>()
				.ReverseMap();

			// Cover mappings
			CreateMap<Covers, CoverDTO>()
				.ForMember(dest => dest.Artists, opt => opt.MapFrom(src =>
					src.ArtistCovers.Select(ac => ac.Artist)))
				.ReverseMap()
				.ForMember(dest => dest.ArtistCovers, opt => opt.Ignore()); // Handle separately if needed
		}
	}
}
