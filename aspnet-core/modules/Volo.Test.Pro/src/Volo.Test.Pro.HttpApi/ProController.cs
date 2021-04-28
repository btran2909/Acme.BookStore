using Volo.Test.Pro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Test.Pro
{
    public abstract class ProController : AbpController
    {
        protected ProController()
        {
            LocalizationResource = typeof(ProResource);
        }
    }
}
