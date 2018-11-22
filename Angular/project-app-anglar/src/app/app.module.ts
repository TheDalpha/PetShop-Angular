import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CustomersListComponent } from './custormers/customers-list/customers-list.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { AppRoutingModule } from './app-routing.module';
import { CustomerDetailsComponent } from './custormers/customer-details/customer-details.component';
import { CustomerAddComponent } from './custormers/customer-add/customer-add.component';
import { CustomerUpdateComponent} from './custormers/customer-update/customer-update.component';
import {HttpClientModule} from '@angular/common/http';
import {LoginComponent} from './custormers/customer-login/customer-login.component';
import {AuthenticationService} from './shared/services/authentication.service';
import {CustomerService} from './shared/services/customer.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AuthGuard} from './shared/guard/auth.guard';
import {HomeComponent} from './shared/home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    CustomersListComponent,
    NavbarComponent,
    WelcomeComponent,
    CustomerDetailsComponent,
    CustomerAddComponent,
    CustomerUpdateComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthGuard,
    AuthenticationService,
    CustomerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
