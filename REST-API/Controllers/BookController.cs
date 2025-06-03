using AutoMapper;
using Core.DTO;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using REST_API.Objects;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly BookUseCase _usecase;
        private readonly IMapper _mapper;
        public BookController(BookUseCase usecase, IMapper mapper)
        {
            _usecase = usecase;
            _mapper = mapper;
        }

        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO bookDto)
        {
            // Map DTO to EF entity
            var book = _mapper.Map<Books>(bookDto);
            await _usecase.CreateBook(book);

            return Ok(book);
        }
    }
}
