using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace abp.EntityFrameworkCore
{
    [DependsOn(
        typeof(abpEntityFrameworkCoreModule)
    )]
    public class abpEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<abpMigrationsDbContext>();
        }
    }
}