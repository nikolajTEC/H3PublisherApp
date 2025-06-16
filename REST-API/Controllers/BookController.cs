using AutoMapper;
using Core.DTO;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using REST_API.Objects;
using REST_API.Requests;

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
            var book = _mapper.Map<Books>(bookDto);
            await _usecase.CreateBook(book);

            return Ok(book);
        }
		[HttpPost("delete-book")]
		public async Task<IActionResult> DeleteBook(int bookId)
		{
			await _usecase.DeleteBook(bookId);

			return Ok();
		}

        [HttpGet("get-books")]
        public async Task<List<BookDTO>> GetBooks()
        {
            var books = await _usecase.GetBooks();
            //return authors;
            var result = _mapper.Map<List<BookDTO>>(books);

            return result;
        }
        [HttpGet("get-books-by-authorId")]
        public async Task<List<BookDTO>> GetBooksByAuthorId(int authorId)
        {
            var books = await _usecase.GetBooksByAuthorId(authorId);
            //return authors;
            var result = _mapper.Map<List<BookDTO>>(books);

            return result;
        }

        [HttpPost("search-books")]
        public async Task<List<BookDTO>> SearchBooks([FromBody] SearchBooksRequest request)
        {
            var books = await _usecase.GetBooksBySearchCriteriaAsync(request.Name, request.StartDate, request.EndDate, request.Price, request.Under);

            var result = _mapper.Map<List<BookDTO>>(books);
            return result;
        }

        [HttpPost("edit-book")]
        public async Task<IActionResult> EditBook([FromBody] BookDTO bookDto)
        {
            var book = _mapper.Map<Books>(bookDto);
            await _usecase.EditBook(book);

            return Ok(book);
        }
    }
}
 