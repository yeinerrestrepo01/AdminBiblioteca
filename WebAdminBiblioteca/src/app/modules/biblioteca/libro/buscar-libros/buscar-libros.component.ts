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
    let objeclibros = {
      Nombres: this.formGroup.value.nombrelibro,
      IdAutor: parseInt(this.formGroup.value.autor),
      IdCategoria: parseInt(this.formGroup.value.categoria),
    }
    console.log(objeclibros);
  }
}
