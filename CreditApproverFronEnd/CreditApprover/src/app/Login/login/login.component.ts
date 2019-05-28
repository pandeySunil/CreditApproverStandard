import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
import{LoginService} from '../Services/login.service';
import {Login} from '../models/loginmodel'
import{AuthService} from '../../auth.service'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  private loginService: LoginService;
  private service:LoginService
  constructor(private s:LoginService,private fb: FormBuilder,private formBuilder: FormBuilder,public authService:AuthService) { 
    this.service = s;
  }
  public loginForm: FormGroup;
  ngOnInit() {
   
    this.createForm();
  }
  get f() {
    return this.loginForm.controls;
   }
   onSubmit(){
    let loginModel:Login = new Login();
    loginModel.MobileNo = this.loginForm.controls.MobileNo.value;
    loginModel.Password = this.loginForm.controls.Password.value;
    loginModel.UserProfiles = [];
     this.service.loginUser(loginModel).subscribe((s)=>{
      if(s.toString()!=""||s.toString()!="undefined"){}
      this,this.authService.setCurrentUser(s.toString());
    });
   }
  createForm() {
    this.loginForm = this.fb.group({
      MobileNo: ['', [Validators.required]],
     Password: ['', Validators.required],
    })
   }
}

