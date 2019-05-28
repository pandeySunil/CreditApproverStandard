import { Injectable } from '@angular/core';
import { HttpClient, HttpParams,HttpHeaders } from '@angular/common/http';
import { map } from "rxjs/operators"; 
import {Login} from '../models/loginmodel'
import { Observable } from 'rxjs';
import { mapChildrenIntoArray } from '@angular/router/src/url_tree';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
 private token:string;
  constructor(public http: HttpClient) { }
  public loginUser(model: Login):Observable<any[]> 
    {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json',
        })
      };
        return this.http.post("http://localhost:50610/api/Values",model,httpOptions).pipe(map((response: any) => {return response}));
    }
}
