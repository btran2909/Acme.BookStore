using abp.Localization;
using Volo.Abp.Application.Services;

namespace abp
{
    /* Inherit your application services from this class.
     */
    public abstract class abpAppService : ApplicationService
    {
        protected abpAppService()
        {
            LocalizationResource = typeof(abpResource);
        }
    }
}
