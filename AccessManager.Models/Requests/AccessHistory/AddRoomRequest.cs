using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddRoomRequest
    {
        [MinLength(1, ErrorMessage = "Invalid room name.")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
