using Volo.Abp.Modularity;

namespace abp
{
    [DependsOn(
        typeof(abpApplicationModule),
        typeof(abpDomainTestModule)
        )]
    public class abpApplicationTestModule : AbpModule
    {

    }
}