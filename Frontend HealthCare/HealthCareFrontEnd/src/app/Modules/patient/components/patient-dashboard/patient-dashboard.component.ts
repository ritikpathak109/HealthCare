import { Component, OnInit } from '@angular/core';
import { PatientServiceService } from 'src/app/Services/patient-service.service';

@Component({
  selector: 'app-patient-dashboard',
  templateUrl: './patient-dashboard.component.html',
  styleUrls: ['./patient-dashboard.component.css']
})
export class PatientDashboardComponent implements OnInit {
  userName: string | null = '';
  roleName: string | null = '';
  userId: string | null = '';
  patientDetails: any;
  constructor(private patientser: PatientServiceService ) {}

  ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.roleName = localStorage.getItem('roleName');
    this.userId = localStorage.getItem('userId');

    if (this.userId) {
      this.loadPatientDetails(this.userId);

    }
  }

  loadPatientDetails(userId: string){
    this.patientser.getPatientDetails(userId).subscribe((res:any)=> {
      this.patientDetails = res[0];
      console.log(this.patientDetails);
      

    });
  }


}
