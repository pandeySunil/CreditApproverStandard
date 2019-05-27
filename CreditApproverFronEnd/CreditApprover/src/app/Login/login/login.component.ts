import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import{LoginService} from '../Services/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  private loginService: LoginService;
  constructor( service:LoginService,private fb: FormBuilder,private formBuilder: FormBuilder,) { 
    this.loginService = LoginService;
  }

  ngOnInit() {
   
    this.createForm();
  }
  createForm() {
    this.loginForm = this.fb.group({
     UserName: ['', [Validators.required]],
     Password: ['', Validators.required],
    })
   }
}
