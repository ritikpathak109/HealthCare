import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PatientRoutingModule } from './patient-routing.module';
import { PatientRegistrationComponent } from './components/patient-registration/patient-registration.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { PatientDashboardComponent } from './components/patient-dashboard/patient-dashboard.component';


@NgModule({
  declarations: [
    PatientRegistrationComponent,
    PatientDashboardComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
 
    ToastrModule.forRoot({ timeOut: 5000,  positionClass: 'toast-top-right',  preventDuplicates: true, })
  ]
})
export class PatientModule { }
