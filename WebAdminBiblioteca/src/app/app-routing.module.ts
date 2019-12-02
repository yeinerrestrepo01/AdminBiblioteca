import { NgModule } from '@angular/core';
import { Routes, RouterModule,PreloadAllModules } from '@angular/router';


const routes: Routes = [{
  path: '',
  loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
},
{
  path: 'home',
  loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
},
  {
    path: 'biblioteca',
    loadChildren: () => import('./modules/biblioteca/biblioteca.module').then(m => m.BibliotecaModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
