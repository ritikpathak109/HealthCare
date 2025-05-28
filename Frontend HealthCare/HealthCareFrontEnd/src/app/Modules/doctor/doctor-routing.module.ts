import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorRegistrationComponent } from './components/doctor-registration/doctor-registration.component';
import { DoctorDashboardComponent } from './components/doctor-dashboard/doctor-dashboard.component';

const routes: Routes = [
  { 
    path: '', component: DoctorRegistrationComponent 
  } ,
    {
      path: 'doctor-dashboard',
      component: DoctorDashboardComponent
    },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
