using System.ComponentModel.DataAnnotations;

namespace REST_API.Requests
{
    public class CreateAuthorRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = null!;
    }
}
