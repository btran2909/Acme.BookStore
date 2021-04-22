import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const AUTHORS_AUTHOR_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/authors',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:Authors',
        layout: eLayoutType.application,
        requiredPolicy: 'abp.Authors',
      },
    ]);
  };
}
