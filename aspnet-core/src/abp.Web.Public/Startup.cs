using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace abp.Web.Public
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<abpWebPublicModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
