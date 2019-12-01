import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { CategoriasService } from 'src/app/shared/services/categorias/categorias.service';

@Component({
  selector: 'app-crear-categoria',
  templateUrl: './crear-categoria.component.html',
  styleUrls: ['./crear-categoria.component.css'],
  providers: [FormBuilder,CategoriasService]
})
export class CrearCategoriaComponent implements OnInit {

   // variables globlales
    listcategorias : any [];

   // form control

   public formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private categoriasService : CategoriasService) { }

  ngOnInit() {
     this.ListCategorias();
    this.formGroup = this.formBuilder.group({
      categoriaNombre: new FormControl("", []),
      descripcioncategoria: new FormControl("", [])
    });

  }

  ListCategorias() {
    this.categoriasService.ListCategorias().subscribe((data: any) => {
      if (!data.isError) {
        this.listcategorias = data.resultado;
        console.log(data);
      }
    });
  }


}
