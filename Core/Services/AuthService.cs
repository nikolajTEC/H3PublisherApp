using Core.DTO;
using Core.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IRepository _repo;
        public AuthService(IConfiguration config, IRepository repo)
        {
            _config = config;
            _repo = repo;
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Register(UserDTO userDTO)
        {
            var user = new User
            {
                Username = userDTO.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password),
                Role = userDTO.Role,
            };
            await _repo.AddAsync(user);
        }

        public async Task<string?> Login(string name, string password)
        {
            var user = await _repo.GetUserByName(name);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;
            var token = GenerateToken(user);
            return token;
        }
    }
}
