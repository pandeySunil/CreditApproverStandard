import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule,HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import{intercept} from '../app/interceptor/intecept';
import { CreateUserComponent } from './CreateUser/create-user/create-user.component'
export const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: CreateUserComponent }] 
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CreateUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    HttpClientModule,
    
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: intercept, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
