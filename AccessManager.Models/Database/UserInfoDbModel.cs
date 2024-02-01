using AccessManager.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessManager.Models.Database
{
    [Table("user")]
    public class UserDbModel
    {
        [Column("employee_id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role_id")]
        public UserRole Role { get; set; }
    }
}
