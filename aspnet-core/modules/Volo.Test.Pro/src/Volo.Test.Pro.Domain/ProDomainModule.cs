using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ProDomainSharedModule)
    )]
    public class ProDomainModule : AbpModule
    {

    }
}
