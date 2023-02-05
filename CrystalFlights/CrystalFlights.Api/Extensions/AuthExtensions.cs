using CrystalFlights.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrystalFlights.Api.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddJWTTokenAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = authOptions.Issuer,
                       ValidAudience = authOptions.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SecureKey))
                   };
               });

            return services;
        }
    }
}
