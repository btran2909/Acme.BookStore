import { Component } from '@angular/core';
// import { ConfigStateService, eLayoutType, RoutesService } from '@abp/ng.core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent {
  // isFeature: boolean | string = false;

  // constructor(
  //   private config: ConfigStateService,
  //   private routes: RoutesService
  // ) {
  //   this.isFeature = config.getFeature("Pro.EnableLdapPro").toLocaleLowerCase()
  //   const abpSession = JSON.parse(localStorage.getItem('abpSession'))
  //   if(abpSession && !abpSession.tenant.id) {
  //     this.addRoutes()
  //   } else {
  //     if(this.isFeature == 'true')
  //       this.addRoutes()
  //   }
  // }

  // addRoutes() {
  //   this.routes.add([
  //     {
  //       path: '/pro',
  //       name: 'Pro::Menu:Pro',
  //       iconClass: 'fas fa-book',
  //       layout: eLayoutType.application,
  //       order: 3
  //     },
  //   ])
  // }
}
