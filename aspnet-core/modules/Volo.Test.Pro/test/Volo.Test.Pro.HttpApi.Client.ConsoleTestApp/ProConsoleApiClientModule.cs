using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(ProHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProConsoleApiClientModule : AbpModule
    {
        
    }
}
