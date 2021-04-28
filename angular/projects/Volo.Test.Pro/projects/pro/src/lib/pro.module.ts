import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ProComponent } from './components/pro.component';
import { ProRoutingModule } from './pro-routing.module';

@NgModule({
  declarations: [ProComponent],
  imports: [CoreModule, ThemeSharedModule, ProRoutingModule],
  exports: [ProComponent],
})
export class ProModule {
  static forChild(): ModuleWithProviders<ProModule> {
    return {
      ngModule: ProModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ProModule> {
    return new LazyModuleFactory(ProModule.forChild());
  }
}
