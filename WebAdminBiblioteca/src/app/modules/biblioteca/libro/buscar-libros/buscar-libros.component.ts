import { Component, OnInit } from '@angular/core';
import { AutoresService } from 'src/app/shared/services/Autores/autores.service';
import { CategoriasService } from 'src/app/shared/services/categorias/categorias.service';
import { LibrosService } from 'src/app/shared/services/Libros/libros.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-buscar-libros',
  templateUrl: './buscar-libros.component.html',
  styleUrls: ['./buscar-libros.component.css'],
  providers: [FormBuilder]
})
export class BuscarLibrosComponent implements OnInit {

  listAutores: any[];
  listcategorias: any[];
  listLibros: any[];
  idlibro: any;
  dropdownList = [];
  selectedItems: any[];
  itemautorid: any;

  // form control

  public formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private serviceAutores: AutoresService,
    private categoriasService: CategoriasService,
    private serviceslibros: LibrosService) { }

  ngOnInit() {
    this.ListAutores();
    this.ListCategorias();
    this.formGroup = this.formBuilder.group({
      autor: new FormControl("", []),
      categoria: new FormControl("", []),
      nombrelibro: new FormControl("", [])
    });
    this.formGroup.controls.categoria.setValue("");
    this.formGroup.controls.autor.setValue("");
  }

  ListAutores() {
    this.serviceAutores.ListAutoress().subscribe((data: any) => {
      if (!data.isError) {
        this.listAutores = data.resultado;
        console.log(this.listAutores)
      }
    });
  }

  ListCategorias() {
    this.categoriasService.ListCategorias().subscribe((data: any) => {
      if (!data.isError) {
        this.listcategorias = data.resultado;
      }
    });
  }
  Buscar(){
    debugger
    let objeclibros = {
      Nombres: this.formGroup.value.nombrelibro,
      IdAutor: this.formGroup.value.autor != '' ? parseInt(this.formGroup.value.autor):0,
      IdCategoria: this.formGroup.value.categoria != '' ? parseInt(this.formGroup.value.categoria):0,
    }

    this.serviceslibros.ListLibrosParametros(objeclibros.Nombres, objeclibros.IdAutor, objeclibros.IdCategoria).subscribe((data: any) => {
      if (!data.isError) {
        this.listLibros = data.resultado;
      }
    });
    console.log(objeclibros);
  }
}
