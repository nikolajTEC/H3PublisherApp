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
				.ReverseMap()
				.ForMember(dest => dest.ArtistCovers, opt => opt.Ignore());

			// Author mappings
			CreateMap<Authors, AuthorDTO>()
				.ReverseMap()
				.ForMember(dest => dest.Books, opt => opt.Ignore());

			// Book mappings
			CreateMap<Books, BookDTO>()
				.ReverseMap()
				.ForMember(dest => dest.Author, opt => opt.Ignore());

			// Cover mappings
			CreateMap<Covers, CoverDTO>()
				.ForMember(dest => dest.Artists, opt => opt.MapFrom(src =>
					src.ArtistCovers != null ? src.ArtistCovers.Select(ac => ac.Artist) : new List<Artists>()))
				.ReverseMap()
				.ForMember(dest => dest.ArtistCovers, opt => opt.Ignore())
				.ForMember(dest => dest.Book, opt => opt.Ignore())
				.AfterMap((src, dest, context) =>
				{
					if (src.Artists != null && src.Artists.Any())
					{
						dest.ArtistCovers = src.Artists.Select(artistDto => new ArtistCover
						{
							ArtistsId = artistDto.ArtistsId,
							Artist = context.Mapper.Map<Artists>(artistDto),
							CoversId = dest.CoversId,
							Cover = dest
						}).ToList();
					}
				});
		}
	}
}
