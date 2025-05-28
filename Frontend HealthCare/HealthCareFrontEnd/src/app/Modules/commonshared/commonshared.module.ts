import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommonsharedRoutingModule } from './commonshared-routing.module';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';


@NgModule({
  declarations: [
    NavbarComponent,
    SidebarComponent
  ],
  imports: [
    CommonModule,
    CommonsharedRoutingModule
  ],
  exports: [
    NavbarComponent,
    SidebarComponent
  ],
})
export class CommonsharedModule { }
