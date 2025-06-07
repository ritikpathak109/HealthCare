import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorRegistrationComponent } from './components/doctor-registration/doctor-registration.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DoctorDashboardComponent } from './components/doctor-dashboard/doctor-dashboard.component';
import { TodaysAppointmentComponent } from './components/todays-appointment/todays-appointment.component';



@NgModule({
  declarations: [
    DoctorRegistrationComponent,
    DoctorDashboardComponent,
    TodaysAppointmentComponent
  ],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DoctorModule { }
