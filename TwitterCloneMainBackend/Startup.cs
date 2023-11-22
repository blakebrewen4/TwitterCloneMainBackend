using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TwitterCloneAPIUserAuth2._0.Data;
using TwitterCloneAPIUserAuth2._0.Services;
using TwitterCloneAPIUserAuth2._0.Repositories;
using TwitterCloneAPIUserAuth2._0.Extensions;
using TwitterCloneShared.SharedModels;
using TwitterCloneAPIUserAuth2._0.Middlewares;
using TwitterCloneTweetServiceAPI.Services;
using TwitterCloneAPIUserAuth2._0;
using TwitterCloneTweetServiceAPI.Data;
using TwitterCloneUserProfileAPI.Services;
// Add other necessary using statements
// Ensure to include using statements for other APIs if they have unique dependencies

namespace TwitterCloneMainBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // User Authentication Services
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<AuthDbContext>()
                    .AddDefaultTokenProviders();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // Populate token validation parameters
                        };
                    });
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<AuthenticationService>();

            // Tweet Service
            services.AddDbContext<TwitterCloneTweetDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<TweetService>();

            // User Profile Service
            // Ensure that the UserProfileService is defined in one of your class libraries
            services.AddScoped<UserProfileService>();

            // Add services for other APIs
            // ...

            services.AddControllers();
            services.AddSwaggerGen(); // Optional, but useful for API documentation
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<ExceptionMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Add other necessary middleware as required
            // ...
        }
    }
}
