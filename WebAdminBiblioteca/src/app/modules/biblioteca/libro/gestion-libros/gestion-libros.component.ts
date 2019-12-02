import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AutoresService } from 'src/app/shared/services/Autores/autores.service';
import { CategoriasService } from 'src/app/shared/services/categorias/categorias.service';
import { LibrosService } from 'src/app/shared/services/Libros/libros.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { AutoresModel } from 'src/app/model/AutoresModel';

@Component({
  selector: 'app-gestion-libros',
  templateUrl: './gestion-libros.component.html',
  styleUrls: ['./gestion-libros.component.css'],
  providers: [FormBuilder]
})
export class GestionLibrosComponent implements OnInit {
  public model: any;
  isupdate: boolean = false;
  listAutores: any[];
  listcategorias: any[];
  listLibros: any[];
  idlibro: any;
  dropdownList = [];
  selectedItems: any[];
  dropdownSettings: IDropdownSettings;
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
    this.ListLibros();

    this.formGroup = this.formBuilder.group({
      autor: new FormControl("", []),
      categoria: new FormControl("", []),
      nombrelibro: new FormControl("", []),
      isbn: new FormControl("", [])
    });
    this.dropdownSettings = {
      singleSelection: true,
      idField: 'idAutor',
      textField: 'nombre',
      selectAllText: 'Seleccionar todo',
      unSelectAllText: 'Deseleccione todos',
      itemsShowLimit: 3,
      allowSearchFilter: true
    }
  }

  ListAutores() {
    this.serviceAutores.ListAutoress().subscribe((data: any) => {
      if (!data.isError) {
        this.listAutores = data.resultado;
        this.dropdownList = this.listAutores;
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
      this.ListLibros();
      this.cancelar();
    });

  }
  EditarRegistro(libro: any) {
    debugger
    this.idlibro = libro.idLibro;
    this.formGroup.controls['nombrelibro'].setValue(libro.nombreLibro);
    this.formGroup.controls['autor'].setValue(libro.idAutor);
    this.formGroup.controls['categoria'].setValue(libro.idCategoria);
    this.formGroup.controls['isbn'].setValue(libro.isbn);
    this.isupdate = true;
    this.itemautorid = libro.idAutor;
  }

  ActualizarRegistro() {
    debugger
    let objeclibros = {
      Nombres: this.formGroup.value.nombrelibro,
      IdAutor: parseInt(this.itemautorid),
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
      this.ListLibros();
      this.cancelar();
      this.isupdate = false;
    });
  }

  RegistrarLibro() {
    if (this.formGroup.value.categoria == '' || this.itemautorid == '') 
    {
      alert("Por favor valide que se haya seleccionado una categoria y autor");

    } else {
      let objectlibros = {
        Nombres: this.formGroup.value.nombrelibro,
        IdAutor: parseInt(this.itemautorid),
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
        this.ListLibros();
        this.cancelar();
      });
    }

  }


  cancelar() {
    this.isupdate = false;
  }
  onItemSelect(selectItem: any) {
    debugger;
    this.dropdownSettings.idField = selectItem.idAutor;
    this.itemautorid = selectItem.idAutor;
  }

}
