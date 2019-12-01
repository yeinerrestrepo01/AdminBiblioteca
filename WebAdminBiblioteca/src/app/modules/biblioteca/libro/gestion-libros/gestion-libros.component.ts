import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AutoresService } from 'src/app/shared/services/Autores/autores.service';
import { CategoriasService } from 'src/app/shared/services/categorias/categorias.service';
import { LibrosService } from 'src/app/shared/services/Libros/libros.service';

@Component({
  selector: 'app-gestion-libros',
  templateUrl: './gestion-libros.component.html',
  styleUrls: ['./gestion-libros.component.css'],
  providers: [FormBuilder]
})
export class GestionLibrosComponent implements OnInit {

  isupdate: boolean = false;
  listAutores: any[];
  listcategorias: any[];
  listLibros: any[];
  idlibro: any;

  // form control

  public formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, 
    private serviceAutores: AutoresService,
    private categoriasService: CategoriasService,
    private serviceslibros : LibrosService) { }

  ngOnInit() {
    this.ListAutores();
    this.ListCategorias();
    this.ListLibros();

    this.formGroup = this.formBuilder.group({
      autor: new FormControl("", []),
      categoria: new FormControl("", []),
      nombrelibro: new FormControl("", []),
      isbn: new FormControl("", [])
    });
  }

  ListAutores() {
    this.serviceAutores.ListAutoress().subscribe((data: any) => {
      if (!data.isError) {
        this.listAutores = data.resultado;
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

  ListLibros() {
    this.serviceslibros.ListLibros().subscribe((data: any) => {
      if (!data.isError) {
        this.listLibros = data.resultado;
      }
    });
  }

  RemoverLibro(libro: any) {
    this.serviceslibros.RemoverLibro(libro.idLibro).subscribe((data: any) => {

      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.isupdate = false;
      this.ListAutores();
    });

  }
  EditarRegistro(libro:any)
  {
    this.idlibro = libro.idLibro;
    this.formGroup.controls['nombrelibro'].setValue(libro.nombreLibro);
    this.formGroup.controls['autor'].setValue(libro.idAutor);
    this.formGroup.controls['categoria'].setValue(libro.idCategoria);
    this.formGroup.controls['isbn'].setValue(libro.isbn);
    this.isupdate = true;
  }

  ActualizarRegistro() {

    let objeclibros= {
      Nombres: this.formGroup.value.nombreautor,
      IdAutor: 1,
      IdCategoria: parseInt(this.formGroup.value.categoria),
      ISBN: this.formGroup.value.isbn
    }

    this.serviceslibros.EditarLibro(this.idlibro, objeclibros).subscribe((data: any) => {
      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.isupdate = false;
      this.ListAutores();
    });
  }

  RegistrarLibro() {

    let objectlibros= {
      Nombres: this.formGroup.value.nombreautor,
      IdAutor: parseInt(this.formGroup.value.autor),
      IdCategoria: parseInt(this.formGroup.value.categoria),
      ISBN: this.formGroup.value.isbn
    }

    this.serviceslibros.CrearLibro(objectlibros).subscribe((data: any) => {
      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.isupdate = false;
      this.ListAutores();
    });
  }


  cancelar() {
    this.isupdate = false;
    this.formGroup = this.formBuilder.group({
      autor: new FormControl("", []),
      categoria: new FormControl("", []),
      nombrelibro: new FormControl("", []),
      isbn: new FormControl("", [])
    });
    }
}
