using Core.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers
{
    [ApiController]
    [Route("api/artist")]
    public class CoverController : ControllerBase
    {
        private readonly CoverUseCase _useCase;

        public CoverController(CoverUseCase useCase)
        {
            _useCase = useCase;
        }
    }
}
