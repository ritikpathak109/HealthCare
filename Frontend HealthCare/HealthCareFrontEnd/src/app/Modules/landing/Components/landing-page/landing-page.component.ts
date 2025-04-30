import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent {
  constructor(private router: Router) { }

  navigateToAdmin() {
    localStorage.setItem('userRoleId', '1');
    localStorage.setItem('userRoleName', 'admin');
    this.router.navigate(['/admin']);
  }

  navigateToDoctor() {
    localStorage.setItem('userRoleId', '3');
    localStorage.setItem('userRoleName', 'doctor');
    this.router.navigate(['/doctor']);
  }

  navigateToPatient() {
    localStorage.setItem('userRoleId', '2');
    localStorage.setItem('userRoleName', 'patient');
    this.router.navigate(['/patient']);
  }
}
