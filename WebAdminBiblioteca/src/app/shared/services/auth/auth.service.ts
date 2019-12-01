import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Api } from '../../api/api';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,private api: Api) {
  }

  RequestToken()
  {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.api.post("token/token", 
    {  
      "username": "AdminBiblioteca",  
      "password": "Admin123"  
    },
    headers).subscribe((res: any) => {
      this.SaveToken(res);
    });
  }

  SaveToken(res){
    localStorage.setItem("token", res.token);
    localStorage.setItem("nombres", res.nombres);
    localStorage.setItem("apellidos", res.apellidos);
    localStorage.setItem("username", res.username);
    localStorage.setItem("expires", res.expires);
  }

  GetToken()
  {
    return localStorage.getItem("token");
  }
}
