import { Injectable, Injector } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AuthService } from './shared/services/auth/auth.service';
import { map, catchError } from 'rxjs/operators';

@Injectable()
export class Interceptor implements HttpInterceptor {
    constructor(private injector: Injector) {}

  intercept(request: HttpRequest <any> , callback) 
  {
    let authService = this.injector.get(AuthService);
      
    if (!request.url.endsWith("token/token")) 
    {
      request = request.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          'Authorization': `bearer ${authService.GetToken()}`
        }
      });
    }

    return callback.handle(request).pipe(
      map((event: HttpEvent<any>) => {
          return event;
      }),
      catchError((error: HttpErrorResponse) => {       
        if (error.status == 401)
        {
            console.log(error);
        }
        return throwError(error);
    }));
  }
}
