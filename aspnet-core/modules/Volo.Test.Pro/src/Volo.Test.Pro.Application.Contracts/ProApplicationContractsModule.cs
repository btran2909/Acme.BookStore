using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(ProDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ProApplicationContractsModule : AbpModule
    {

    }
}
