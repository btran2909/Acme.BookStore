using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Acme.BookStore.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace Acme.BookStore.Web.Public.Menus
{
    public class BookStorePublicMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public BookStorePublicMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<BookStoreResource>();

            //Home
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    BookStorePublicMenus.HomePage,
                    l["Menu:Home"],
                    "~/",
                    icon: "fa fa-home",
                    order: 1
                )
            );

            // ArticleSample
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    BookStorePublicMenus.ArticleSample,
                    l["Menu:ArticleSample"],
                    "~/article-sample",
                    icon: "fa fa-file-signature",
                    order: 2
                    )
            );

            // Contact Us
            context.Menu.AddItem(
                new ApplicationMenuItem(
                    BookStorePublicMenus.ContactUs,
                    l["Menu:ContactUs"],
                    "~/contact-us",
                    icon: "fa fa-phone",
                    order: 3
                    )
            );

            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            if (currentUser.IsAuthenticated)
            {
                var identityServerUrl = _configuration["AuthServer:Authority"] ?? "~";
                var uiResource = context.GetLocalizer<AbpUiResource>();
                var accountResource = context.GetLocalizer<AccountResource>();
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["ManageYourProfile"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{identityServerUrl.EnsureEndsWith('/')}Account/SecurityLogs", target: "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}
