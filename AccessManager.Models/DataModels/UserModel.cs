using AccessManager.Models.Database;
using AccessManager.Models.Enum;

namespace AccessManager.Models.DataModels
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public static explicit operator UserModel(UserDbModel dbUser) => new UserModel
        {
            Id = dbUser.Id,
            Email = dbUser.Email,
            Password = dbUser.Password,
            Role = dbUser.Role
        };
    }
}
