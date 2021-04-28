using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(ProApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Pro";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
