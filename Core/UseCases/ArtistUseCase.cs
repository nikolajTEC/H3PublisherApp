using REST_API.Objects;

namespace Core.UseCases
{
    public class ArtistUseCase : CrudUseCase<Artists>
    {
        public ArtistUseCase(IGenericRepo repo) : base(repo)
        {
        }

        public async Task CreateArtist(string firstname, string lastName)
        {
            var artist = new Artists(firstname, lastName);
            await AddAsync(artist);
        }
        public async Task DeleteArtist(int id)
        {
            var artist = await GetByIdAsync(id);
            await DeleteAsync(artist);
        }
        public async Task EditArtist(int id, string? firstName, string? lastName)
        {
            var artist = await GetByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(firstName) && artist.FirstName != firstName)
                artist.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName) && artist.LastName != lastName)
                artist.LastName = lastName;

            await UpdateAsync(artist);
        }
    }
}
