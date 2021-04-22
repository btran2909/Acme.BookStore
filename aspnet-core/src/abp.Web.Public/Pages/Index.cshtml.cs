using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace abp.Web.Public.Pages
{
    public class IndexModel : abpPublicPageModel
    {
        public void OnGet()
        {

        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
