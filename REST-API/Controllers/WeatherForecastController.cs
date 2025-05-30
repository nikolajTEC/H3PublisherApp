using AutoMapper;
using Core.DTO;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Objects;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CreateUseCases _authorUseCase;
        private readonly IMapper _mapper;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CreateUseCases authorUseCase, IMapper mapper)
        {
            _logger = logger;
            _authorUseCase = authorUseCase;
            _mapper = mapper;
        }

        [HttpPost("create-author")]
        public async Task<IActionResult> CreateAuthor(string firstName, string lastName)
        {
            await _authorUseCase.CreateAuthor(firstName, lastName);
            return Ok(); // returns the created author with its generated Id
        }
        [HttpPost("create-book")]
        public async Task<IActionResult> CreateBook(string title, DateTime publishDate, double basePrice, int authorId)
        {
            await _authorUseCase.CreateBook(title, publishDate, basePrice, authorId);
            return Ok();
        }

        [HttpPost("create-cover")]
        public async Task<IActionResult> CreateCover(string title, bool digitalOnly, int bookId)
        {
            await _authorUseCase.CreateCover(title, digitalOnly, bookId);
            return Ok();
        }

        [HttpPost("create-artist")]
        public async Task<IActionResult> CreateArtist(string firstName, string lastName)
        {
            await _authorUseCase.CreateArtist(firstName, lastName);
            return Ok(); // returns the created author with its generated Id
        }

        [HttpGet("authors")]
        public async Task<List<AuthorDTO>> GetAuthors()
        {
            var authors = await _authorUseCase.GetAuthors();
            //return authors;
            var result = _mapper.Map<List<AuthorDTO>>(authors);

            return result;
        }
    }
}
