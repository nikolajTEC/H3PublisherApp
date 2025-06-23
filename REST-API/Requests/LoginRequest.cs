using System.ComponentModel.DataAnnotations;

namespace REST_API.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Must provide username")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Must provide password")]
        public string Password { get; set; } = null!;
    }
}
