import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CurrencyKitComponent } from './components/currency-kit.component';
import { CurrencyKitRoutingModule } from './currency-kit-routing.module';

@NgModule({
  declarations: [CurrencyKitComponent],
  imports: [CoreModule, ThemeSharedModule, CurrencyKitRoutingModule],
  exports: [CurrencyKitComponent],
})
export class CurrencyKitModule {
  static forChild(): ModuleWithProviders<CurrencyKitModule> {
    return {
      ngModule: CurrencyKitModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CurrencyKitModule> {
    return new LazyModuleFactory(CurrencyKitModule.forChild());
  }
}
