using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/artist")]
    public class ArtistController
    {
        private readonly ArtistUseCase _useCase;

        public ArtistController(ArtistUseCase useCase)
        {
            _useCase = useCase;
        }
    }
}
