using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace abp
{
    [Dependency(ReplaceServices = true)]
    public class abpBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "abp";
    }
}
