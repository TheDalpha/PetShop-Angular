import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {WelcomeComponent} from './welcome/welcome.component';
import {CustomersListComponent} from './custormers/customers-list/customers-list.component';
import {CustomerDetailsComponent} from './custormers/customer-details/customer-details.component';
import {CustomerAddComponent} from './custormers/customer-add/customer-add.component';
import {CustomerUpdateComponent} from './custormers/customer-update/customer-update.component';
import {LoginComponent} from './custormers/customer-login/customer-login.component';
import {HomeComponent} from './shared/home/home.component';
import {AuthGuard} from './shared/guard/auth.guard';

const routes: Routes = [
  { path: 'customers', component: CustomersListComponent },
  { path: 'customer-add', component: CustomerAddComponent },
  { path: 'customer-update/:id', component: CustomerUpdateComponent },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'customers/:id', component: CustomerDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
