using AccessManager.Models.Database;
using AccessManager.Models.Enum;
using AccessManager.Models.Requests.AccessHistory;

namespace AccessManager.Models.DataModels
{
    public class EventInfo
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid RoomId { get; set; }

        public EventType EventTypeId { get; set; }

        public DateTime Time { get; set; }

        public static explicit operator EventInfo(EventDbModel db) => new EventInfo
        {
            Id = db.Id,
            EmployeeId = db.EmployeeId,
            RoomId = db.RoomId,
            EventTypeId = db.EventTypeId,
            Time = db.Time
        };

        public static explicit operator EventInfo(AddEventRequest db) => new EventInfo
        {
            Id = Guid.NewGuid(),
            EmployeeId = db.EmployeeId,
            RoomId = db.RoomId,
            EventTypeId = db.EventTypeId,
            Time = db.Time
        };

        public static implicit operator EventDbModel(EventInfo db) => new EventDbModel
        {
            Id = db.Id,
            EmployeeId = db.EmployeeId,
            RoomId = db.RoomId,
            EventTypeId = db.EventTypeId,
            Time = db.Time
        };
    }
}
