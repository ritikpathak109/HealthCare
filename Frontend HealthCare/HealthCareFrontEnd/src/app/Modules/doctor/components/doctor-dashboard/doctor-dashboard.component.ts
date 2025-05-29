import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-dashboard',
  templateUrl: './doctor-dashboard.component.html',
  styleUrls: ['./doctor-dashboard.component.css']
})
export class DoctorDashboardComponent {


  constructor(private router: Router) { }
  
    logout(){

     localStorage.clear();
       this.router.navigate(['/login']);
  }

}
