using AutoMapper;
using Core.DTO;
using REST_API.Objects;

namespace Core.UseCases
{
    public class AuthorUseCase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AuthorUseCase(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<Authors>> GetAuthors()
        {
            var authors = await _repo.GetAuthorsAsNoTracking();
            return authors;
        }
        public async Task CreateAuthor(string firstName, string lastName)
        {
            var author = new Authors(firstName, lastName);
            await _repo.AddAsync(author);
        }
        public async Task EditAuthor(string? firstName, string? lastName, int id)
        {
            var author = await _repo.GetByIdAsync<Authors>(id);

            if (!string.IsNullOrWhiteSpace(firstName) && author.FirstName != firstName)
                author.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName) && author.LastName != lastName)
                author.LastName = lastName;

            await _repo.UpdateAsync(author!);
        }
        public async Task DeleteAuthor(int id)
        {
            var author = _repo.GetByIdAsync<Authors>(id);
            await _repo.DeleteAsync(author);
        }
    }
}
