import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from '@angular/router';
import {WelcomeComponent} from './welcome/welcome.component';
import {CustomersListComponent} from './custormers/customers-list/customers-list.component';
import {CustomerDetailsComponent} from './custormers/customer-details/customer-details.component';
import {CustomerAddComponent} from './custormers/customer-add/customer-add.component';
import {CustomerUpdateComponent} from './custormers/customer-update/customer-update.component';

const routes: Routes = [
  { path: 'customers', component: CustomersListComponent },
  { path: 'customer-add', component: CustomerAddComponent },
  { path: 'customer-update/:id', component: CustomerUpdateComponent },
  { path: '', component: WelcomeComponent },
  { path: 'customers/:id', component: CustomerDetailsComponent }
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
