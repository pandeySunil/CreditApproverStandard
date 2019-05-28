import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';
@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  public signInForm: FormGroup;
  constructor(private fb: FormBuilder,private formBuilder: FormBuilder,) { }

  ngOnInit() {
    this.createForm();
  }
  get f() {
    return this.signInForm.controls;
   }         
  createForm() {
    this.signInForm = this.fb.group({
     UserName: ['', [Validators.required]],
     Password: ['', [Validators.required]],
     EmailId: ['', [Validators.required]],
     MobileNo: ['', [Validators.required]],
    })
   }
}
