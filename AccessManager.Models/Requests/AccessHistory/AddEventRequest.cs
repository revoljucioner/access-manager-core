using AccessManager.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddEventRequest
    {
        [Required(ErrorMessage = "EmployeeId is required")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "RoomId is required")]
        public Guid RoomId { get; set; }

        [Required(ErrorMessage = "EventTypeId is required")]
        public EventType EventTypeId { get; set; }

        [Required(ErrorMessage = "Time is required")]
        public DateTime Time { get; set; }
    }
}
