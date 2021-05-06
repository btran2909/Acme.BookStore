using Volo.Test.Pro.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Volo.Test.Pro.Feature
{
    public class ProFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var group = context.AddGroup(ProFeature.GroupName,
                L("Feature:ProGroup"));

            group.AddFeature(ProFeature.EnableLdapPro,
                false.ToString(),
                L("Feature:EnableLdapPro"),
                L("Feature:EnableLdapPro"),
                new ToggleStringValueType());
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProResource>(name);
        }
    }
}
