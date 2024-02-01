namespace AccessManager.Models.Requests.AccessHistory
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? DepartmentId { get; set; }
    }
}
