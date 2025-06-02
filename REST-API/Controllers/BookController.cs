using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController
    {
        private readonly BookUseCase _usecase;

        public BookController(BookUseCase usecase)
        {
            _usecase = usecase;
        }
    }
}
