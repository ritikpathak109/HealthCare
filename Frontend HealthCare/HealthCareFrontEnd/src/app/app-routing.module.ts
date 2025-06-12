import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserloginComponent } from './Modules/login/components/userlogin/userlogin.component';

const routes: Routes = [

  { path: 'login', component: UserloginComponent }, 
  { path: 'landing', loadChildren: () => import('./Modules/landing/landing.module').then(m => m.LandingModule) },
  { path: 'admin', loadChildren: () => import('./Modules/admin/admin.module').then(m => m.AdminModule) },
  { path: 'doctor', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'patient', loadChildren: () => import('./Modules/patient/patient.module').then(m => m.PatientModule) },
  { path: 'book-appointment', loadChildren: () => import('./Modules/patient/patient.module').then(m => m.PatientModule) },
  { path: 'manage-appointment', loadChildren: () => import('./Modules/patient/patient.module').then(m => m.PatientModule) },
  { path: 'doctor-dashboard', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'todays-appointment', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'doctor-consultation', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'finalConsultationSlip', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: '', redirectTo: 'login', pathMatch: 'full' },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
