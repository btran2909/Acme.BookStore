import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const BOOKS_BOOK_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/books',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:Books',
        layout: eLayoutType.application,
        requiredPolicy: 'abp.Books',
      },
    ]);
  };
}
