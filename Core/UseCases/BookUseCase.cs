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

        public async Task CreateBook(Books book)
        {
            await _repo.AddAsync(book);
        }
        public async Task DeleteBook(int id)
        {
            var book = await _repo.GetByIdAsync<Books>(id);
            await _repo.DeleteAsync(book);
        }
    }
}
