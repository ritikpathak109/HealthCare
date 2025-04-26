import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorRegistrationComponent } from './components/doctor-registration/doctor-registration.component';

const routes: Routes = [
  { 
    path: '', component: DoctorRegistrationComponent 
  } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
