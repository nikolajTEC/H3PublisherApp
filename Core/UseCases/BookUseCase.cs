using REST_API.Objects;

namespace Core.UseCases
{
    public class BookUseCase
    {
        private readonly IRepository _repo;

        public BookUseCase(IRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateBook(Books book)
        {
            await _repo.AddAsync(book);
        }
        public async Task DeleteBook(int id)
        {
            var book = await _repo.GetByIdAsync<Books>(id);
            await _repo.DeleteAsync(book);
        }
        public async Task<List<Books>> GetBooks()
        {
            var books = await _repo.GetBooksAsNoTracking();
            return books;
        }
        public async Task<List<Books>> GetBooksByAuthorId(int authorId)
        {
            var books = await _repo.GetBooksByAuthorIdAsNoTracking(authorId);
            return books;
        }

        public async Task EditBook(int id, string? title, DateOnly? publishDate, double? basePrice)
        {
            var book = await _repo.GetByIdAsync<Books>(id);

            if (!string.IsNullOrWhiteSpace(title) && book.Title != title)
                book.Title = title;

            if (publishDate != null && book.PublishDate != publishDate)
                book.PublishDate = (DateOnly)publishDate!;
            if (basePrice != null && book.BasePrice != basePrice)
                book.BasePrice = (double)basePrice;

            await _repo.UpdateAsync(book!);
        }

        public async Task<List<Books>> GetBooksBySearchCriteriaAsync(string? name, DateTime? startDate, DateTime? endDate, double? price, bool under)
        {
            var books = await _repo.GetBooksBySearchCriteriaAsync(name, startDate, endDate, price, under);

            return books;
        }
    }
}
