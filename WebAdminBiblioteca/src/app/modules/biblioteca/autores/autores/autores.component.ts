import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { AutoresService } from 'src/app/shared/services/Autores/autores.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css'],
  providers: [FormBuilder, DatePipe]
})
export class AutoresComponent implements OnInit {

  isupdate: boolean = false;
  listAutores: any[];
  idautor: any;

  // form control

  public formGroup: FormGroup;

  constructor(private formBuilder: FormBuilder, private serviceAutores: AutoresService, private datePipe: DatePipe) { }

  ngOnInit() {

    this.ListAutores();

    this.formGroup = this.formBuilder.group({
      nombreautor: new FormControl("", []),
      apellidoautor: new FormControl("", []),
      fechanacimiento: new FormControl("", [])
    });

  }


  ListAutores() {
    this.serviceAutores.ListAutoress().subscribe((data: any) => {
      if (!data.isError) {
        this.listAutores = data.resultado;
      }
    });
  }

  RemoverAutor(autor: any) {
    this.serviceAutores.RemoverAutores(autor.idAutor).subscribe((data: any) => {

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

  RegistraAutor() {
    let objectautores = {
      Nombres: this.formGroup.value.nombreautor,
      Apellidos: this.formGroup.value.apellidoautor,
      FechaNacimiento: this.formGroup.value.fechanacimiento
    }

    this.serviceAutores.CrearAutores(objectautores).subscribe((data: any) => {
      if (!data.isError) {
        alert(data.mensaje);
      }
      else {
        alert(data.mensaje);
      }
      this.ListAutores();
    });
    this.isupdate = false;
  }


  EditarRegistro(autores: any) {
    this.idautor = autores.idAutor;
    let datefecha: any;
    let newfecha: any;
    if (autores.fechaNacimiento != null) {
      datefecha = autores.fechaNacimiento.split('/');
      newfecha = datefecha[1] + "/" + datefecha[0] + "/" + datefecha[2];
    }
    this.formGroup.controls['nombreautor'].setValue(autores.nombre);
    this.formGroup.controls['apellidoautor'].setValue(autores.apellidos);
    this.formGroup.controls['fechanacimiento'].setValue(this.datePipe.transform(autores.fechaNacimiento, 'yyyy-MM-dd'));
    this.isupdate = true;
  }

  ActualizarAutor() {

    let objectautores = {
      Nombres: this.formGroup.value.nombreautor,
      Apellidos: this.formGroup.value.apellidoautor,
      FechaNacimiento: this.formGroup.value.fechanacimiento
    }

    this.serviceAutores.EditarAutores(this.idautor, objectautores).subscribe((data: any) => {
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
      nombreautor: new FormControl("", []),
      apellidoautor: new FormControl("", []),
      fechanacimiento: new FormControl("", [])
    });
  }
}
