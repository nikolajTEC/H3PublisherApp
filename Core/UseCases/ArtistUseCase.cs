using REST_API.Objects;

namespace Core.UseCases
{
    public class ArtistUseCase
    {
        private readonly IRepository _repo;

        public ArtistUseCase(IRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateArtist(string firstname, string lastName)
        {
            var artist = new Artists(firstname, lastName);
            await _repo.AddAsync(artist);
        }
        public async Task DeleteArtist(int id)
        {
            var artist = _repo.GetByIdAsync<Artists>(id);
            await _repo.DeleteAsync(artist);
        }
        public async Task EditArtist(int id, string? firstName, string? lastName)
        {
            var artist = await _repo.GetByIdAsync<Artists>(id);

            if (!string.IsNullOrWhiteSpace(firstName) && artist.FirstName != firstName)
                artist.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName) && artist.LastName != lastName)
                artist.LastName = lastName;

            await _repo.UpdateAsync(artist!);
        }
    }
}
