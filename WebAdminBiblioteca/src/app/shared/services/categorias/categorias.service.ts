import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Api } from '../../api/api';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient,private api: Api) {
  }

  ListCategorias(){
    return this.api.get('api/categorias')
  }

  RemoverCategoria(idcategoria:any){
        return this.api.delete('api/categorias/' + idcategoria);
  }

  CrearCategoria(objectcategoria : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.post("api/categorias",objectcategoria,  { headers: headers });
   }

   EditarCategoria(idcategoria :any ,objectcategoria : any){
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.put("api/categorias/" + idcategoria,objectcategoria,  { headers: headers });
   }
}
