import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'abp',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44379',
    redirectUri: baseUrl,
    clientId: 'abp_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone abp',
  },
  apis: {
    default: {
      url: 'https://localhost:44379',
      rootNamespace: 'abp',
    },
  },
} as Environment;
