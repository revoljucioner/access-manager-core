using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddDepartmentRequest
    {
        [MinLength(1, ErrorMessage = "Invalid department name.")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
