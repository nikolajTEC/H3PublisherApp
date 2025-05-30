using REST_API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public class CreateUseCases
    {
        private readonly IRepository _repo;
        public CreateUseCases(IRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateAuthor(string firstName, string lastName)
        {
            var author = new Authors(firstName, lastName);
            await _repo.AddAuthor(author);
        }

        public async Task CreateBook(string title, DateTime publishDate, double basePrice, int authorId)
        {
            var book = new Books(title, publishDate, basePrice, authorId);
            await _repo.AddBook(book);
        }

        public async Task CreateCover(string title, bool digitalOnly, int bookId)
        {
            var cover = new Covers(title, digitalOnly, bookId);
            await _repo.AddCover(cover);
        }
        public async Task CreateArtist(string firstname, string lastName)
        {
            var artist = new Artists(firstname, lastName);
            await _repo.AddArtist(artist);
        }

        public async Task<List<Authors>> GetAuthors()
        {
            var authors = await _repo.GetAuthors();
            return authors;
        }
    }
}
