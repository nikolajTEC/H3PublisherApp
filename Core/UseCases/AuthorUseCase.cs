using AutoMapper;
using Core.DTO;
using REST_API.Objects;

namespace Core.UseCases
{
    public class AuthorUseCase : CrudUseCase<Authors>
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AuthorUseCase(IGenericRepo genericRepo, IMapper mapper, IRepository repo) : base(genericRepo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<Authors>> GetAuthors()
        {
            var authors = await _repo.GetAuthorsAsNoTracking();
            return authors;
        }
        public async Task CreateAuthor(string firstName, string lastName)
        {
            var author = new Authors(firstName, lastName);
            await AddAsync(author);
        }
        public async Task EditAuthor(string? firstName, string? lastName, int id)
        {
            var author = await GetByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(firstName) && author.FirstName != firstName)
                author.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName) && author.LastName != lastName)
                author.LastName = lastName;

            await UpdateAsync(author);
        }
        public async Task DeleteAuthor(int id)
        {
            var author = await GetByIdAsync(id);
            await DeleteAsync(author);
        }
    }
}
