using AccessManager.Sso.Attributes.FromClaimAttribute;
using AccessManager.Sso.Certificates;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AccessManager.Sso.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAsymmetricAuthentication(this IServiceCollection services)
        {
            services.AddSingleton<TokenService>();

            var issuerSigningCertificate = new SigningIssuerCertificate();
            RsaSecurityKey issuerSigningKey = issuerSigningCertificate.GetIssuerSigningKey();
            services.AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = issuerSigningKey,
                        LifetimeValidator = LifetimeValidator
                    };
                });

            return services;
        }

        public static IServiceCollection AddClaimBinding(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.ValueProviderFactories.Add(new ClaimValueProviderFactory());
            });

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<FromClaimSwaggerIgnoreFilter>();
            });

            return services;
        }

        private static bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires != null && expires > DateTime.UtcNow;
        }
    }
}