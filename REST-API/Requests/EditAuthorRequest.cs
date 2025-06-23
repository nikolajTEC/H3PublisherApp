using System.ComponentModel.DataAnnotations;

namespace REST_API.Requests
{
    public class EditAuthorRequest
    {
        [Required(ErrorMessage = "Must have an Id for edited entity")]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
