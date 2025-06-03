using AutoMapper;
using Core.DTO;
using REST_API.Objects;

namespace REST_API.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BookDto, Book>()
				.ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Cover));

			CreateMap<CoverDto, Cover>()
				.ForMember(dest => dest.ArtistCovers, opt => opt.MapFrom(src =>
					src.Artists.Select(a => new ArtistCover
					{
						Artist = new Artist
						{
							FirstName = a.FirstName,
							LastName = a.LastName
						}
					}).ToList()
				));

			CreateMap<ArtistDto, Artist>();
		}
	}
}
