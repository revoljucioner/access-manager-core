using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AccessManager.Sso
{
    public class CustomAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Connection.RemoteIpAddress.ToString() == Environment.GetEnvironmentVariable("CLUSTER_IP"))
            {
                var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Role, "Admin")
            }, "custom");

                context.User = new ClaimsPrincipal(identity);
            }

            await _next(context);
        }
    }
}