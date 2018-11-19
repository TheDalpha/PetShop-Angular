import { Component, OnInit } from '@angular/core';
import {Customer} from '../../shared/models/customer';
import {CustomerService} from '../../shared/services/customer.service';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {
  customers: Customer[];


  constructor(private customerService: CustomerService) { }
  ngOnInit() {
    this.customers = this.customerService.getCustomers();
  }

  delete(id: number) {
    this.customerService.deleteCustomer(id);
    this.customers = this.customerService.getCustomers();
  }




}
