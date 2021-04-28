import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProComponent } from './components/pro.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ProComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProRoutingModule {}
