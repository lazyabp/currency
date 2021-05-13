import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CurrencyKit',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44390',
    redirectUri: baseUrl,
    clientId: 'CurrencyKit_App',
    responseType: 'code',
    scope: 'offline_access CurrencyKit',
  },
  apis: {
    default: {
      url: 'https://localhost:44390',
      rootNamespace: 'Lazy.Abp.CurrencyKit',
    },
    CurrencyKit: {
      url: 'https://localhost:44335',
      rootNamespace: 'Lazy.Abp.CurrencyKit',
    },
  },
} as Environment;
