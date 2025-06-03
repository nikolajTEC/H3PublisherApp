using REST_API.Objects;

namespace Core
{
    public interface IRepository
    {
        Task<List<Authors>> GetAuthorsAsNoTracking();

        Task AddAsync<T>(T entity) where T : class;
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<List<Books>> GetBooksAsNoTracking();
        Task<List<Books>> GetBooksByAuthorIdAsNoTracking(int authorId);
    }
}
