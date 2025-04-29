import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { UserloginComponent } from './components/userlogin/userlogin.component';
import { ReactiveFormsModule } from '@angular/forms';  // Import ReactiveFormsModule

@NgModule({
  declarations: [
    UserloginComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule,
  ]
})
export class LoginModule { }
