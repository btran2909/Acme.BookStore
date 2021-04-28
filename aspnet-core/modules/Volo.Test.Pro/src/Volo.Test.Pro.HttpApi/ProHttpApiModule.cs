using Localization.Resources.AbpUi;
using Volo.Test.Pro.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Volo.Test.Pro
{
    [DependsOn(
        typeof(ProApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ProHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ProResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
