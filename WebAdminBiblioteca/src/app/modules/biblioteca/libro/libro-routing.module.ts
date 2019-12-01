import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GestionLibrosComponent } from './gestion-libros/gestion-libros.component';


const routes: Routes = [
  {
    path: 'gestion-libros',
    component: GestionLibrosComponent,
    data: {
      breadcrumbs: 'Gestion Libros'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibroRoutingModule { }
