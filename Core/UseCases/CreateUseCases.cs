using REST_API.Objects;

namespace Core.UseCases
{
    public class CreateUseCases
    {
        private readonly IRepository _repo;
        public CreateUseCases(IRepository repo)
        {   
            _repo = repo;
        }       
    }
}
