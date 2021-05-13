import { ModuleWithProviders, NgModule } from '@angular/core';
import { CURRENCY_KIT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CurrencyKitConfigModule {
  static forRoot(): ModuleWithProviders<CurrencyKitConfigModule> {
    return {
      ngModule: CurrencyKitConfigModule,
      providers: [CURRENCY_KIT_ROUTE_PROVIDERS],
    };
  }
}
