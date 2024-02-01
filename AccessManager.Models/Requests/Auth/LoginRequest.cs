using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.Auth
{
    public class LoginRequest
    {
        [RegularExpression(@"^ *[\w-\.]+@([\w-]+\.)+[\w-]{2,4} *$", ErrorMessage = "Invalid email format.")]
        [MinLength(1, ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
