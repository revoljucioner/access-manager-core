using AccessManager.Models.Enum;

namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddEventRequest
    {
        public Guid EmployeeId { get; set; }

        public Guid RoomId { get; set; }

        public EventType EventTypeId { get; set; }

        public DateTime Time { get; set; }
    }
}
