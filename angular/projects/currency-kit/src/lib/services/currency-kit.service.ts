import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CurrencyKitService {
  apiName = 'CurrencyKit';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CurrencyKit/sample' },
      { apiName: this.apiName }
    );
  }
}
