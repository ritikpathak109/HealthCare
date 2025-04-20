import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  { path: 'landing', loadChildren: () => import('./Modules/landing/landing.module').then(m => m.LandingModule) },
  
  { path: 'admin', loadChildren: () => import('./Modules/admin/admin.module').then(m => m.AdminModule) },
  { path: 'doctor', loadChildren: () => import('./Modules/doctor/doctor.module').then(m => m.DoctorModule) },
  { path: 'patient', loadChildren: () => import('./Modules/patient/patient.module').then(m => m.PatientModule) },
  { path: '', redirectTo: 'landing', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
