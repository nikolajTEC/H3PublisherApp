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
    }
}
