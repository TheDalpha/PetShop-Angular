import { Injectable } from '@angular/core';
import {Pet} from '../models/pet';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {AuthenticationService} from './authentication.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  customers: Pet[];
  id = 1;
  constructor(private http: HttpClient, private authenticationService: AuthenticationService) { }

  getCustomers(): Observable<Pet[]> {
     httpOptions.headers =
       httpOptions.headers.set('Authorization', 'Bearer ' + this.authenticationService.getToken());
    return this.http.get<Pet[]>(environment.apiUrl + '/api/pet/', httpOptions);
  }

  addCustomer(customer: Pet) {
    customer.id = this.id++;
  this.customers.push(customer);
  }

  updateCustomer(customer: Pet) {
    const custToUpdate = this.customers.find(cust => customer.id === cust.id);
    const index = this.customers.indexOf(custToUpdate);
    this.customers[index] = customer;
  }

  deleteCustomer(id: number) {
    this.http.delete(environment.apiUrl + '/api/pet/' + id);
    // this.customers = this.customers.filter(cust => cust.id !== id);
  }

  getCustomerById(id: number) {
    return this.customers.find(cust => cust.id === id);
  }
}
