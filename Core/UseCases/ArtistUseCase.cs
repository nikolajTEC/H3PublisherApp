using REST_API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _repo.AddArtist(artist);
        }
        public async Task DeleteArtist(int id)
        {
            var artist = _repo.GetByIdAsync<Artists>(id);
            await _repo.DeleteAsync(artist);
        }
    }
}
