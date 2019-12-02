import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Api } from '../../api/api';
@Injectable({
  providedIn: 'root'
})
export class LibrosService {

 
  constructor(private http: HttpClient,private api: Api) {
  }

  ListLibros(){
    return this.api.get('api/Libros')
  }

  ListLibrosParametros(libro:any, autor: any, categoria:any){
    return this.api.get('api/Libros/GetParametros',{libro:libro, categoria:categoria, autor:autor})
  }

  RemoverLibro(idLibro:any){
        return this.api.delete('api/Libros/' + idLibro);
  }

  CrearLibro(objectLibro : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.post("api/Libros",objectLibro,  { headers: headers });
   }

   EditarLibro(idLibro :any ,objectLibro : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.put("api/Libros/" + idLibro,objectLibro,  { headers: headers });
   }
}
