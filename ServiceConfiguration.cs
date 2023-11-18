using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TwitterCloneMainBackend.Data;
using TwitterCloneAPIUserAuth.Services;

namespace TwitterCloneMainBackend.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            // JWT Authentication
            var jwtSettings = configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"]
                };
            });

            // Database context and additional services
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TwitterDbContext>(options => options.UseSqlServer(connectionString));
            services.AddLogging();
            services.AddAuthorization();

            // Authentication service
            services.AddSingleton<AuthenticationService>();
        }
    }
}
