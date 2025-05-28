import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DoctorRoutingModule } from './doctor-routing.module';
import { DoctorRegistrationComponent } from './components/doctor-registration/doctor-registration.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DoctorDashboardComponent } from './components/doctor-dashboard/doctor-dashboard.component';
import { CommonsharedModule } from '../commonshared/commonshared.module';


@NgModule({
  declarations: [
    DoctorRegistrationComponent,
    DoctorDashboardComponent
  ],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonsharedModule
  ]
})
export class DoctorModule { }
