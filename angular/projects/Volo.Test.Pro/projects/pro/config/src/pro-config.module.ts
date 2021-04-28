import { ModuleWithProviders, NgModule } from '@angular/core';
import { PRO_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ProConfigModule {
  static forRoot(): ModuleWithProviders<ProConfigModule> {
    return {
      ngModule: ProConfigModule,
      providers: [PRO_ROUTE_PROVIDERS],
    };
  }
}
