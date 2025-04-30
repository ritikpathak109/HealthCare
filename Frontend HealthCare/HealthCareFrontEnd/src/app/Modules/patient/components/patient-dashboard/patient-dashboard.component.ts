import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patient-dashboard',
  templateUrl: './patient-dashboard.component.html',
  styleUrls: ['./patient-dashboard.component.css']
})
export class PatientDashboardComponent implements OnInit {
  userName: string | null = '';
  roleName: string | null = '';
  userId: string | null = '';

  constructor() {}

  ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.roleName = localStorage.getItem('roleName');
    this.userId = localStorage.getItem('userId');
  }

  

}
