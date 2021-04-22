using abp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace abp.Web.Public.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class abpPublicPageModel : AbpPageModel
    {
        protected abpPublicPageModel()
        {
            LocalizationResourceType = typeof(abpResource);
        }
    }
}
