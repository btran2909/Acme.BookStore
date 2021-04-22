using Acme.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Public.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class BookStorePublicPageModel : AbpPageModel
    {
        protected BookStorePublicPageModel()
        {
            LocalizationResourceType = typeof(BookStoreResource);
        }
    }
}
