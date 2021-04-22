import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'abp',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44379',
    redirectUri: baseUrl,
    clientId: 'abp_App',
    responseType: 'code',
    scope: 'offline_access abp',
  },
  apis: {
    default: {
      url: 'https://localhost:44379',
      rootNamespace: 'abp',
    },
  },
} as Environment;
