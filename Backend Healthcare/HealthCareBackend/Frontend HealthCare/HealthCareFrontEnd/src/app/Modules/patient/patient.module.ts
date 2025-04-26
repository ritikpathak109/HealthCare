import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientRoutingModule } from './patient-routing.module';
import { PatientRegistrationComponent } from './components/patient-registration/patient-registration.component';


@NgModule({
  declarations: [
    PatientRegistrationComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule
  ]
})
export class PatientModule { }
