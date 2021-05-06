import { CoreModule } from '@abp/ng.core';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxsModule } from '@ngxs/store';
import { AccountConfigModule } from '@volo/abp.ng.account/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityServerConfigModule } from '@volo/abp.ng.identity-server/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { HttpErrorComponent, ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { AUTHORS_AUTHOR_ROUTE_PROVIDER } from './authors/author/providers/author-route.provider';
import { BOOKS_BOOK_ROUTE_PROVIDER } from './books/book/providers/book-route.provider';
// import { ProConfigModule } from 'projects/Volo.Test.Pro/projects/pro/config/src/public-api';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    ThemeSharedModule.forRoot({
      httpErrorConfig: {
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      },
    }),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    IdentityServerConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    NgxsModule.forRoot([]),
    ThemeLeptonModule.forRoot(),
    // ProConfigModule.forRoot()
  ],
  providers: [APP_ROUTE_PROVIDER, AUTHORS_AUTHOR_ROUTE_PROVIDER, BOOKS_BOOK_ROUTE_PROVIDER],
  bootstrap: [AppComponent],
})
export class AppModule {}
