import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorService } from 'src/app/Services/doctor.service';

@Component({
  selector: 'app-doctor-dashboard',
  templateUrl: './doctor-dashboard.component.html',
  styleUrls: ['./doctor-dashboard.component.css']
})
export class DoctorDashboardComponent implements OnInit {

userName: string | null = '';
roleName: string | null = '';
userId: string | null = '';
doctorDetails: any;
  constructor(private router: Router, private doctorService: DoctorService) { }



ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.roleName = localStorage.getItem('roleName');
    this.userId = localStorage.getItem('userId');

    if (this.userId) {
      this.loadDoctorDetails(this.userId);
    

    }
  }

  loadDoctorDetails(userId: string){
    this.doctorService.getDoctorDetails(userId).subscribe((res:any)=> {
      this.doctorDetails = res[0];
       localStorage.setItem('DoctorId', this.doctorDetails.doctorId);
      
    });
  }

    logout(){

     localStorage.clear();
       this.router.navigate(['/login']);
  }

}
