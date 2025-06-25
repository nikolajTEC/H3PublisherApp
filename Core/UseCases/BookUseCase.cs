using AutoMapper;
using REST_API.Objects;

namespace Core.UseCases
{
    public class BookUseCase : CrudUseCase<Books>
    {
        private readonly IRepository _repo;

        public BookUseCase(IGenericRepo genericRepo, IRepository repo) : base(genericRepo)
        {
            _repo = repo;
        }

        public async Task CreateBook(Books book)
        {
            await AddAsync(book);
        }
        public async Task DeleteBook(int id)
        {
            var book = await GetByIdAsync(id);
            await DeleteAsync(book);
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
        
        public async Task EditBook(Books book)
        {
            var oldbook = await _repo.GetBookAndChildObjectsAsync(book.Id);
            oldbook.BasePrice = book.BasePrice;
            oldbook.Title = book.Title;
            oldbook.PublishDate = book.PublishDate;
            if (book.Cover != null)
            {
                if (oldbook.Cover != null)
                {
                    oldbook.Cover.Title = book.Cover.Title;
                    oldbook.Cover.DigitalOnly = book.Cover.DigitalOnly;
                }
                else
                {
                    oldbook.Cover = book.Cover;
                }
            }

            await UpdateAsync(oldbook);
        }
        public async Task<List<Books>> GetBooksBySearchCriteriaAsync(string? name, DateTime? startDate, DateTime? endDate, double? price, bool under)
        {
            var books = await _repo.GetBooksBySearchCriteriaAsync(name, startDate, endDate, price, under);

            return books;
        }
    }
}
