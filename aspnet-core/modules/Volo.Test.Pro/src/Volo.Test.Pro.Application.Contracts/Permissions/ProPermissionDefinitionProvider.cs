using Volo.Test.Pro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Volo.Test.Pro.Permissions
{
    public class ProPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ProPermissions.GroupName, L("Permission:Pro"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProResource>(name);
        }
    }
}