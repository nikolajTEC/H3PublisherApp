using REST_API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public class BookUseCase
    {
        private readonly IRepository _repo;

        public BookUseCase(IRepository repo)
        {
            _repo = repo;
        }

        //public async Task CreateBook(string title, DateTime publishDate, double basePrice, int authorId)
        //{
        //    var book = new Books(title, publishDate, basePrice, authorId);
        //    await _repo.AddBook(book);
        //}
        public async Task CreateBook(Books book)
        {
            await _repo.AddBook(book);
        }
        public async Task DeleteBook(int id)
        {
            var book = _repo.GetByIdAsync<Books>(id);
            await _repo.DeleteAsync(book);
        }
    }
}
