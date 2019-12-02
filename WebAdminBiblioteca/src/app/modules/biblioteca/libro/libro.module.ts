import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibroRoutingModule } from './libro-routing.module';
import { GestionLibrosComponent } from './gestion-libros/gestion-libros.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { BuscarLibrosComponent } from './buscar-libros/buscar-libros.component';


@NgModule({
  declarations: [GestionLibrosComponent, BuscarLibrosComponent],
  imports: [
    CommonModule,
    LibroRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgMultiSelectDropDownModule
  ]
})
export class LibroModule { }
