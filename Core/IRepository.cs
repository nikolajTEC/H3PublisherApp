using REST_API.Objects;

namespace Core
{
    public interface IRepository
    {
        Task AddAuthor(Authors author);
        Task AddBook(Books book);
        Task AddCover(Covers cover);
        Task AddArtist(Artists artists);
        Task<List<Authors>> GetAuthors();

        Task AddAsync<T>(T entity) where T : class;
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
