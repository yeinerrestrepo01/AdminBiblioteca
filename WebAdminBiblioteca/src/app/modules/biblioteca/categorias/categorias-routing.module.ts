import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CrearCategoriaComponent } from './crear-categoria/crear-categoria.component';


const routes: Routes = [
  {
    path: 'crearcategoria',
    component: CrearCategoriaComponent,
    data: {
      breadcrumbs: 'Crearcategoria'
    }
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriasRoutingModule { }
