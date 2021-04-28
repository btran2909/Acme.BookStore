using Volo.Test.Pro.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Test.Pro
{
    public abstract class ProAppService : ApplicationService
    {
        protected ProAppService()
        {
            LocalizationResource = typeof(ProResource);
            ObjectMapperContext = typeof(ProApplicationModule);
        }
    }
}
