import { Component, OnInit } from '@angular/core';
import { BookAppointmentService } from 'src/app/Services/book-appointment.service';

@Component({
  selector: 'app-manage-appointment',
  templateUrl: './manage-appointment.component.html',
  styleUrls: ['./manage-appointment.component.css']
})
export class ManageAppointmentComponent implements OnInit {

  appointmentList: any;
  deletedAppointmentList: any;
  constructor(private bookser: BookAppointmentService) { }


  ngOnInit(): void {
   this.getAppointmentByPatientId();
   this.getDeletedAppointments();
  }

  getAppointmentByPatientId() {
    const patientId = localStorage.getItem('PatientId');
    this.bookser.getAppointmentByPatientId(patientId).subscribe((res: any) => {
      this.appointmentList = res;

    });
  }
  deleteAppointment(appointmentId: any) { 
     if (confirm('Are you sure you want to delete this appointment?')) {
    this.bookser.deleteAppointment(appointmentId).subscribe((res) => {
      alert(res); 
      this.getAppointmentByPatientId();
      this.getDeletedAppointments();
    });
  }
  }
  getDeletedAppointments() {
    const patientId = localStorage.getItem('PatientId');
    this.bookser.getDeletedAppointments(patientId).subscribe((res: any) => {
      this.deletedAppointmentList = res;
   
    });
  }

}
