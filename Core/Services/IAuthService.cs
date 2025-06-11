using Core.DTO;

namespace Core.Services
{
    public interface IAuthService
    {
        Task<string?> Login(string name, string password);
        Task Register(UserDTO userDTO);
    }
}