using Core.Objects;
using REST_API.Objects;

namespace Core
{
    public interface IRepository
    {
        Task<List<Authors>> GetAuthorsAsNoTracking();
        Task<List<Books>> GetBooksAsNoTracking();
        Task<List<Books>> GetBooksByAuthorIdAsNoTracking(int authorId);
        Task<User?> GetUserByName(string name);

        Task<List<Books>> GetBooksBySearchCriteriaAsync(string? name, DateTime? startDate, DateTime? endDate, double? price, bool under);
    }
}
