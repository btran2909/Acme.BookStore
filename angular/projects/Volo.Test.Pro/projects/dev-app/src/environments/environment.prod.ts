import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Pro',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44325',
    redirectUri: baseUrl,
    clientId: 'Pro_App',
    responseType: 'code',
    scope: 'offline_access Pro',
  },
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'Volo.Test.Pro',
    },
    Pro: {
      url: 'https://localhost:44391',
      rootNamespace: 'Volo.Test.Pro',
    },
  },
} as Environment;
