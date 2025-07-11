import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {
  userForm: FormGroup;

  constructor(private router: Router, private fb: FormBuilder, private loginser: LoginService) {
    this.userForm = this.fb.group({
      UserName: ['', [Validators.required]],
      UserPassword: ['', [Validators.required]],
    });
  }
  ngOnInit(){
    localStorage.removeItem('userName');
    localStorage.removeItem('roleName');
    localStorage.removeItem('userId');
    localStorage.removeItem('userRoleId');
    localStorage.removeItem('PatientId');
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
      localStorage.setItem('userId', res.userId);
    
      if (res.roleName === 'Admin') {
        this.router.navigate(['/admin']);
      } else if (res.roleName === 'Doctor') {
        this.router.navigate(['/doctor/doctor-dashboard']);
      } else if (res.roleName === 'Patient') {
        this.router.navigate(['/patient/dashboard']);
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
