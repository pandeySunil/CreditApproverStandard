import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse }
  from '@angular/common/http';

import { Observable } from 'rxjs';

export class intercept implements HttpInterceptor {
    constructor(){

       
    }

    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
      ): Observable<HttpEvent<any>> {
    
        return next.handle(req.clone({headers:req.headers.append('Authorization',localStorage.getItem("currentUser").toString())}));
    
      }
}