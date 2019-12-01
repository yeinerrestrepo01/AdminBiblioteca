import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibroRoutingModule } from './libro-routing.module';
import { GestionLibrosComponent } from './gestion-libros/gestion-libros.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [GestionLibrosComponent],
  imports: [
    CommonModule,
    LibroRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class LibroModule { }
