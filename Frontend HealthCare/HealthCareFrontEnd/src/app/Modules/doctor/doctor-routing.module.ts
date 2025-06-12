import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorRegistrationComponent } from './components/doctor-registration/doctor-registration.component';
import { DoctorDashboardComponent } from './components/doctor-dashboard/doctor-dashboard.component';
import { TodaysAppointmentComponent } from './components/todays-appointment/todays-appointment.component';
import { DoctorConsultationComponent } from './components/doctor-consultation/doctor-consultation.component';
import { FinalConsultationSlipComponent } from './components/final-consultation-slip/final-consultation-slip.component';

const routes: Routes = [
  { 
    path: '', component: DoctorRegistrationComponent 
  } ,
    {
      path: 'doctor-dashboard',
      component: DoctorDashboardComponent
    },
    {
      path: 'todays-appointment',
      component: TodaysAppointmentComponent
    },
     {
      path: 'doctor-consultation/:appointmentId', component: DoctorConsultationComponent
    },
     {
      path: 'finalConsultationSlip',
      component: FinalConsultationSlipComponent
    }
    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { }
