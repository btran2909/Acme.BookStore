using Volo.Abp.Reflection;

namespace Volo.Test.Pro.Permissions
{
    public class ProPermissions
    {
        public const string GroupName = "Pro";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ProPermissions));
        }
    }
}