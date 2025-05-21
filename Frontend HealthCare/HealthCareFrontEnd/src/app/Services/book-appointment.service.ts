import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookAppointmentService {

  constructor(private http : HttpClient) { }

   getAvailableSlots(doctorId:any, appointmentDate:any){
    return this.http.get( `http://localhost:5165/api/AvailableSlot/GetAvailable-Slots?doctorId=${doctorId}&appointmentDate=${appointmentDate}`)

  }

  bookAppointment(appointmentData:any){
    return this.http.post('http://localhost:5165/api/Appointment/add-appointment', appointmentData , {responseType: 'text'})
  }
}
