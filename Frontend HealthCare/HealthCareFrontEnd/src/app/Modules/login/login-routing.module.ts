import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserloginComponent } from './components/userlogin/userlogin.component';

const routes: Routes = [

  { path: '', component: UserloginComponent } 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],

  exports: [RouterModule]
})
export class LoginRoutingModule { }
