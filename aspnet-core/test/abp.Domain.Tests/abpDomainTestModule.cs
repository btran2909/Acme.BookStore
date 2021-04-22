using abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace abp
{
    [DependsOn(
        typeof(abpEntityFrameworkCoreTestModule)
        )]
    public class abpDomainTestModule : AbpModule
    {

    }
}