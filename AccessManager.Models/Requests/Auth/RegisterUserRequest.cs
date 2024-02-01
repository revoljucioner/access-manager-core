using AccessManager.Models.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.Auth
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "EmployeeId is required.")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,32}$", ErrorMessage = "Password must be at least 4 characters, no more than 32 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^ *[\w-\.]+@([\w-]+\.)+[\w-]{2,4} *$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public UserRole? Role { get; set; }
    }
}
