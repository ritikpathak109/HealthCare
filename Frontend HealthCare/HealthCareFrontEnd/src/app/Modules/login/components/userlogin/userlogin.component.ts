import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent {
  userForm: FormGroup;

  constructor(private router: Router, private fb: FormBuilder, private loginser: LoginService) {
    this.userForm = this.fb.group({
      UserName: ['', [Validators.required]],
      UserPassword: ['', [Validators.required]],
    });
  }



onNavigateToLanding() {
  this.router.navigate(['/landing']);
}
onLogin() {
  if (this.userForm.invalid) {
    this.userForm.markAllAsTouched();
    return;
  }


  
  this.loginser.loginUser(this.userForm.value).subscribe({
    next: (res) => {
      console.log(res);

      localStorage.setItem('userName', res.userName);
      localStorage.setItem('roleName', res.roleName);

      if (res.roleName === 'Admin') {
        this.router.navigate(['/admin']);
      } else if (res.roleName === 'Doctor') {
        this.router.navigate(['/doctor']);
      } else if (res.roleName === 'Patient') {
        this.router.navigate(['/patient']);
      } else {
        alert('Unknown role!');
      }
    },
    error: (error) => {
      console.error(error);
      alert('Invalid username or password!');
    }
});
}

}
