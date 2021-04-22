using abp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace abp.Permissions
{
    public class abpPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(abpPermissions.GroupName);

            myGroup.AddPermission(abpPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(abpPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(abpPermissions.MyPermission1, L("Permission:MyPermission1"));

            var authorPermission = myGroup.AddPermission(abpPermissions.Authors.Default, L("Permission:Authors"));
            authorPermission.AddChild(abpPermissions.Authors.Create, L("Permission:Create"));
            authorPermission.AddChild(abpPermissions.Authors.Edit, L("Permission:Edit"));
            authorPermission.AddChild(abpPermissions.Authors.Delete, L("Permission:Delete"));

            var bookPermission = myGroup.AddPermission(abpPermissions.Books.Default, L("Permission:Books"));
            bookPermission.AddChild(abpPermissions.Books.Create, L("Permission:Create"));
            bookPermission.AddChild(abpPermissions.Books.Edit, L("Permission:Edit"));
            bookPermission.AddChild(abpPermissions.Books.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<abpResource>(name);
        }
    }
}