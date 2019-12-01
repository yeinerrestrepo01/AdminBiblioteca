import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AutoresRoutingModule } from './autores-routing.module';
import { AutoresComponent } from './autores/autores.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [AutoresComponent],
  imports: [
    CommonModule,
    AutoresRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AutoresModule { }
