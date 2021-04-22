import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'abp.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'abp.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
