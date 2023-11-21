using TwitterCloneUserProfileAPI.Services;

namespace TwitterCloneUserProfileAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddScoped<UserProfileService>();
            // ...
        }
    }
}
