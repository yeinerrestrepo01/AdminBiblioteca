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
}
