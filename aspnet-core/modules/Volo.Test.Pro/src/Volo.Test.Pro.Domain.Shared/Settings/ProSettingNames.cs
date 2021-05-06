namespace Volo.Test.Pro.Settings
{
    public static class ProSettingNames
    {
        public const string IsSelfRegistrationEnabled = "Abp.Pro.IsSelfRegistrationEnabled";

        public const string EnableLocalLogin = "Abp.Pro.EnableLocalLogin";

        public const string EnableLdapLogin = "Abp.Pro.EnableLdapLogin";

        public const string ProfilePictureSource = "Abp.Pro.ProfilePictureSource";

        public static class TwoFactorLogin
        {
            public const string IsRememberBrowserEnabled = "Abp.Pro.TwoFactorLogin.IsRememberBrowserEnabled";
        }

        public class Captcha
        {
            public const string UseCaptchaOnRegistration = "Abp.Pro.Captcha.UseCaptchaOnRegistration";

            public const string UseCaptchaOnLogin = "Abp.Pro.Captcha.UseCaptchaOnLogin";

            public const string VerifyBaseUrl = "Abp.Pro.Captcha.VerifyBaseUrl";

            public const string SiteKey = "Abp.Pro.Captcha.SiteKey";

            public const string SiteSecret = "Abp.Pro.Captcha.SiteSecret";

            public const string Version = "Abp.Pro.Captcha.Version";

            public const string Score = "Abp.Pro.Captcha.Score";
        }

        public const string ExternalProviders = "Abp.Pro.ExternalProviders";
    }
}
