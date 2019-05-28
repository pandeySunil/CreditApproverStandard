import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { 

    
  }

  public setCurrentUser(token:string){
    localStorage.setItem("currentUser",token);
  }
}
