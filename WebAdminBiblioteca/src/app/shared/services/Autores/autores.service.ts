import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Api } from '../../api/api';

@Injectable({
  providedIn: 'root'
})
export class AutoresService {

  constructor(private http: HttpClient,private api: Api) {
  }

  ListAutoress(){
    return this.api.get('api/Autores')
  }

  RemoverAutores(idAutores:any){
        return this.api.delete('api/Autores/' + idAutores);
  }

  CrearAutores(objectAutores : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.post("api/Autores",objectAutores,  { headers: headers });
   }

   EditarAutores(idAutores :any ,objectAutores : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.put("api/Autores/" + idAutores,objectAutores,  { headers: headers });
   }
}
