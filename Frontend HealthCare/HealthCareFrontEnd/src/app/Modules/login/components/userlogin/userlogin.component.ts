import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent {

  
constructor(private route: Router, private fb: FormBuilder, private loginser: LoginService) { }

onNavigateToLanding() {
  this.route.navigate(['/landing']);
}

userForm = this.fb.group({
  UserName: ['', [Validators.required]],
  UserPassword: ['', [Validators.required]],
});


}
