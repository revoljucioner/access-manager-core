using AccessManager.Models.Database;
using AccessManager.Models.Requests.AccessHistory;

namespace AccessManager.Models.DataModels
{
    public class RoomInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static explicit operator RoomInfo(RoomDbModel db) => new RoomInfo
        {
            Id = db.Id,
            Name = db.Name
        };

        public static explicit operator RoomInfo(AddRoomRequest db) => new RoomInfo
        {
            Id = Guid.NewGuid(),
            Name = db.Name
        };

        public static implicit operator RoomDbModel(RoomInfo db) => new RoomDbModel
        {
            Id = db.Id,
            Name = db.Name
        };
    }
}
