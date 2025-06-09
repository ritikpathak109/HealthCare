import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorService } from 'src/app/Services/doctor.service';

@Component({
  selector: 'app-todays-appointment',
  templateUrl: './todays-appointment.component.html',
  styleUrls: ['./todays-appointment.component.css']
})
export class TodaysAppointmentComponent implements OnInit {

  doctorId:any
  todaysAppointmentList:any;
  constructor(private docservice: DoctorService, private router: Router) { }

  ngOnInit(){
    this.getTodaysAppointment();

  }


  getTodaysAppointment(){
  const doctorId = localStorage.getItem('DoctorId');
    this.docservice.getDoctorTodayAppointment(doctorId).subscribe((res: any) => {
      this.todaysAppointmentList = res;

    });

  }

  logout(){

     localStorage.clear();
       this.router.navigate(['/login']);
  }
  
}
