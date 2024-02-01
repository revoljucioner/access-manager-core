using AccessManager.Models.Enum;
using Microsoft.AspNetCore.Authorization;

namespace AccessManager.Sso.Attributes
{
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        public AuthorizeCustomAttribute(UserRole role)
        {
            Roles = role.ToString();
        }
    }
}
