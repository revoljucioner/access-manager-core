using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddEmployeeRequest
    {
        [MinLength(1, ErrorMessage = "Invalid first name.")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [MinLength(1, ErrorMessage = "Invalid last name.")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public Guid? DepartmentId { get; set; }
    }
}
