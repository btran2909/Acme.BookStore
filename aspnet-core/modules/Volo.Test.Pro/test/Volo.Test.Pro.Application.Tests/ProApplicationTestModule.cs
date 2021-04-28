using Volo.Abp.Modularity;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(ProApplicationModule),
        typeof(ProDomainTestModule)
        )]
    public class ProApplicationTestModule : AbpModule
    {

    }
}
