import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientRegistrationComponent } from './components/patient-registration/patient-registration.component';
import { PatientDashboardComponent } from './components/patient-dashboard/patient-dashboard.component';
import { BookAppointmentComponent } from './components/book-appointment/book-appointment.component';
import { ManageAppointmentComponent } from './components/manage-appointment/manage-appointment.component';

const routes: Routes = [
  { 
    path: '', component: PatientRegistrationComponent 
  } ,
  {
    path: 'dashboard',
    component: PatientDashboardComponent
  },
  {
    path: 'book-appointment',
    component: BookAppointmentComponent
  },
  {
    path: 'manage-appointment',
    component: ManageAppointmentComponent
  },
  

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PatientRoutingModule { }
