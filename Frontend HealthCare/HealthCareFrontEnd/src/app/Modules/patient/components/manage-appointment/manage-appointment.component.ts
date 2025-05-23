import { Component, OnInit } from '@angular/core';
import { BookAppointmentService } from 'src/app/Services/book-appointment.service';

@Component({
  selector: 'app-manage-appointment',
  templateUrl: './manage-appointment.component.html',
  styleUrls: ['./manage-appointment.component.css']
})
export class ManageAppointmentComponent implements OnInit {

  appointmentList: any;
  constructor(private bookser: BookAppointmentService) { }


  ngOnInit(): void {
   this.getAppointmentByPatientId();
  }

  getAppointmentByPatientId() {
    const patientId = localStorage.getItem('PatientId');
    this.bookser.getAppointmentByPatientId(patientId).subscribe((res: any) => {
      this.appointmentList = res;
      console.log(this.appointmentList);
    });
  }
  deleteAppointment(appointmentId: any) { 
     if (confirm('Are you sure you want to delete this appointment?')) {
    this.bookser.deleteAppointment(appointmentId).subscribe((res) => {
      alert(res); 
      this.getAppointmentByPatientId();
    });
  }
  }

}
