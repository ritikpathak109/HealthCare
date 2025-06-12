import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-consultation',
  templateUrl: './doctor-consultation.component.html',
  styleUrls: ['./doctor-consultation.component.css']
})
export class DoctorConsultationComponent implements OnInit {

  constructor(private router: Router) { }
   ngOnInit() {
    
   }

   logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

}
