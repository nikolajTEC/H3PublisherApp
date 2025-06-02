using AutoMapper;
using Core.DTO;
using Core.UseCases;
using Microsoft.AspNetCore.Mvc;
using REST_API.Requests;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/Author")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorUseCase _authorUseCase;
        private readonly IMapper _mapper;

        public AuthorController(AuthorUseCase authorUseCase, IMapper mapper)
        {
            _authorUseCase = authorUseCase;
            _mapper = mapper;
        }

        [HttpPost("create-author")]
        public async Task<IActionResult> CreateAuthor(string firstName, string lastName)
        {
            await _authorUseCase.CreateAuthor(firstName, lastName);
            return Ok(); 
        }

        [HttpGet("get-authors")]
        public async Task<List<AuthorDTO>> GetAuthors()
        {
            var authors = await _authorUseCase.GetAuthors();
            //return authors;
            var result = _mapper.Map<List<AuthorDTO>>(authors);

            return result;
        }

        [HttpPost("edit-author")]
        public async Task<IActionResult> EditAuthor(EditAuthorRequest author)
        {
            await _authorUseCase.EditAuthor(author.FirstName, author.LastName, author.Id);            

            return Ok();
        }
    }
}
