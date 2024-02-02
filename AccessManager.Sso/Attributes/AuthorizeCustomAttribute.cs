using AccessManager.Models.Enum;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AccessManager.Sso.Attributes
{
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        public AuthorizeCustomAttribute(params UserRole[] roles)
        {
            Roles = string.Join(",", roles.Select(i => i.ToString()));
        }
    }
}
