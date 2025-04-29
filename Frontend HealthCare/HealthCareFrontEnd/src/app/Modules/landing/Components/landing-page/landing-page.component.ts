import { Component } from '@angular/core';
import { Router } from '@angular/router';

const ROLE_IDS: { [key: string]: number } = {
  'patient': 1,
  'doctor': 2,
  'admin': 3,
};

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent {
  constructor(private router: Router) { }

  navigateToAdmin() {
    this.setRoleAndNavigate('admin');
  }

  navigateToDoctor() {
    this.setRoleAndNavigate('doctor');
  }

  navigateToPatient() {
    this.setRoleAndNavigate('patient');
  }

  private setRoleAndNavigate(roleName: string) {
    const roleId = ROLE_IDS[roleName];
    if (roleId) {
      localStorage.setItem('userRoleId', roleId.toString());
      localStorage.setItem('userRoleName', roleName);
      this.router.navigate([`/${roleName}`]);
    } else {
      console.error(`Role ID not found for role: ${roleName}`);
    }
  }

}