import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'categorias',
    loadChildren: () => import('../../modules/biblioteca/categorias/categorias.module').then(m => m.CategoriasModule)
  },
  {
    path: 'autores',
    loadChildren: () => import('../../modules/biblioteca/autores/autores.module').then(m => m.AutoresModule)
  },
  {
    path: 'libros',
    loadChildren: () => import('../../modules/biblioteca/libro/libro.module').then(m => m.LibroModule)
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BibliotecaRoutingModule { }
