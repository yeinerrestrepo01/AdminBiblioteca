import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

/**
 * Api is a generic REST Api handler. Set your API url first.
 */
@Injectable()
export class Api {
  url: string = '';


  constructor(public http: HttpClient) {
      this.url='http://localhost:57819/';
  }

  get(endpoint: string, params?: any, reqOpts?: any) {
    if (!reqOpts) {
      reqOpts = {
          params: new HttpParams(),
            header: new HttpHeaders({
                'Content-Type': 'application/json'
              })
      };
    }
    // Support easy query params for GET requests
    if (params) {
      reqOpts.params = new HttpParams();
      for (let k in params) {
        reqOpts.params = reqOpts.params.set(k, params[k]);
      }
    }

    return this.http.get(this.url + endpoint, reqOpts);
  }

  post(endpoint: string, body: any, reqOpts?: any) {
    return this.http.post(this.url + endpoint, body, reqOpts);
  }


 

  put(endpoint: string, body: any, reqOpts?: any) {
    return this.http.put(this.url + endpoint, body, reqOpts);
  }

  delete(endpoint: string, params?: any, reqOpts?: any) {

    if (!reqOpts) {
      
      reqOpts = {
        params: new HttpParams(),
          header: new HttpHeaders({
              'Content-Type': 'application/json'
            })
      };
  }
  // Support easy query params for GET requests
  if (params) {
    reqOpts.params = new HttpParams();
    for (let k in params) {
      reqOpts.params = reqOpts.params.set(k, params[k]);
    }
  }
    return this.http.delete(this.url + endpoint, reqOpts);
  }

  patch(endpoint: string, body: any, reqOpts?: any) {
    return this.http.patch(this.url + endpoint, body, reqOpts);
  }
}
