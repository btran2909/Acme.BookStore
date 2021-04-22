using abp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace abp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(abpEntityFrameworkCoreDbMigrationsModule),
        typeof(abpApplicationContractsModule)
    )]
    public class abpDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.IsJobExecutionEnabled = false;
            });
        }
    }
}