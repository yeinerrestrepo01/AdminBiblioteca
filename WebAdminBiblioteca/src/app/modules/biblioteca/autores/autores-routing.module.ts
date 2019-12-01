import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutoresComponent } from './autores/autores.component';


const routes: Routes = [

  {
    path: 'gestion-autores',
    component: AutoresComponent,
    data: {
      breadcrumbs: 'Autores'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AutoresRoutingModule { }
