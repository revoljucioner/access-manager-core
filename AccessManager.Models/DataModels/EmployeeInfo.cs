using AccessManager.Models.Database;
using AccessManager.Models.Requests.AccessHistory;

namespace AccessManager.Models.DataModels
{
    public class EmployeeInfo
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? DepartmentId { get; set; }

        public static explicit operator EmployeeInfo(EmployeeInfoDbModel db) => new EmployeeInfo
        {
            Id = db.Id,
            FirstName = db.FirstName,
            LastName = db.LastName,
            DepartmentId = db.DepartmentId
        };

        public static explicit operator EmployeeInfo(AddEmployeeRequest db) => new EmployeeInfo
        {
            Id = Guid.NewGuid(),
            FirstName = db.FirstName,
            LastName = db.LastName,
            DepartmentId = db.DepartmentId
        };

        public static implicit operator EmployeeInfoDbModel(EmployeeInfo db) => new EmployeeInfoDbModel
        {
            Id = db.Id,
            FirstName = db.FirstName,
            LastName = db.LastName,
            DepartmentId = db.DepartmentId
        };
    }
}
