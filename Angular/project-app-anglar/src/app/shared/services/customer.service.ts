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

  addCustomer(customer: Pet): Observable<Pet> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'Bearer ' + this.authenticationService.getToken());
  return this.http.post<Pet>(environment.apiUrl + '/api/pet/', customer, httpOptions);
  }

  updateCustomer(customer: Pet): Observable<Pet> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'Bearer ' + this.authenticationService.getToken());
    return this.http.put<Pet>(environment.apiUrl + '/api/pet/' + customer.id, customer, httpOptions);
  }

  deleteCustomer(id: number): Observable<any> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'Bearer ' + this.authenticationService.getToken());
    return this.http.delete(environment.apiUrl + '/api/pet/' + id, httpOptions);
    // this.customers = this.customers.filter(cust => cust.id !== id);
  }

  getCustomerById(id: number): Observable<Pet> {
    httpOptions.headers =
      httpOptions.headers.set('Authorization', 'Bearer ' + this.authenticationService.getToken());
    return this.http.get<Pet>(environment.apiUrl + '/api/pet/' + id, httpOptions);
    // return this.customers.find(cust => cust.id === id);
  }
}
