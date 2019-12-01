import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { CategoriasService } from 'src/app/shared/services/categorias/categorias.service';

@Component({
  selector: 'app-crear-categoria',
  templateUrl: './crear-categoria.component.html',
  styleUrls: ['./crear-categoria.component.css'],
  providers: [FormBuilder, CategoriasService]
})
export class CrearCategoriaComponent implements OnInit {

  // variables globlales
  listcategorias: any[];
  isupdate: boolean = false;
  idcategoria: any;

  // form control

  public formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private categoriasService: CategoriasService) { }

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
      }
    });
  }

  RemoverCategoria(categoria: any) {
    this.categoriasService.RemoverCategoria(categoria.idCategoria).subscribe((data: any) => {

      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.isupdate = false;
      this.ListCategorias();
    });
   
  }

  RegistraCategoria() {
    let objectcategoria = {
      Nombres: this.formGroup.value.categoriaNombre,
      Descripcion: this.formGroup.value.descripcioncategoria
    }

    this.categoriasService.CrearCategoria(objectcategoria).subscribe((data: any) => {
      console.log(data);
      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.ListCategorias();
    });
    this.isupdate = false;
  }


  EditarRegistro(categoria: any) {
    console.log(categoria);
    this.idcategoria = categoria.idCategoria;
    this.formGroup.controls['categoriaNombre'].setValue(categoria.nombre);
    this.formGroup.controls['descripcioncategoria'].setValue(categoria.descripcion);
    this.isupdate = true;
  }

  ActualizarRegistro() {

    let objectcategoria = {
      Nombres: this.formGroup.value.categoriaNombre,
      Descripcion: this.formGroup.value.descripcioncategoria
    }

    this.categoriasService.EditarCategoria(this.idcategoria, objectcategoria).subscribe((data: any) => {
      console.log(data);
      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.isupdate = false;
      this.ListCategorias();
    });
  }

  cancelar() {
    this.isupdate = false;
    this.formGroup = this.formBuilder.group({
      categoriaNombre: new FormControl("", []),
      descripcioncategoria: new FormControl("", [])
    });
    }
}
