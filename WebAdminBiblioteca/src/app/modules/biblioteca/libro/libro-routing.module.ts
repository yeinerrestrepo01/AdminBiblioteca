import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GestionLibrosComponent } from './gestion-libros/gestion-libros.component';
import { BuscarLibrosComponent } from './buscar-libros/buscar-libros.component';


const routes: Routes = [
  {
    path: 'gestion-libros',
    component: GestionLibrosComponent,
  },
  {
    path: 'gestion-busqueda',
    component: BuscarLibrosComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibroRoutingModule { }
