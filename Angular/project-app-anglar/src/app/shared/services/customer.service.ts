import { Injectable } from '@angular/core';
import {Customer} from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  customers: Customer[];
  id = 1;
  constructor() { this.customers = [
    {id: this.id++, firstName: 'John', lastName: 'Johnson', address: 'Home'},
    {id: this.id++, firstName: 'Bill', lastName: 'Billson', address: 'Work'}];
  }

  getCustomers(): Customer[] {
  return this.customers;
  }

  addCustomer(customer: Customer) {
    customer.id = this.id++;
  this.customers.push(customer);
  }

  updateCustomer(customer: Customer) {
    const custToUpdate = this.customers.find(cust => customer.id === cust.id);
    const index = this.customers.indexOf(custToUpdate);
    this.customers[index] = customer;
  }

  deleteCustomer(id: number) {
    this.customers = this.customers.filter(cust => cust.id !== id);
  }

  getCustomerById(id: number) {
    return this.customers.find(cust => cust.id === id);
  }
}
