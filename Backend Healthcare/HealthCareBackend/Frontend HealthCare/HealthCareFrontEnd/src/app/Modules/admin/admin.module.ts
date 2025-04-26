import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminRegistrationComponent } from './components/admin-registration/admin-registration.component';


@NgModule({
  declarations: [
    AdminRegistrationComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
