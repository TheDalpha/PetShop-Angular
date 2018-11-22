import { Component, OnInit } from '@angular/core';
import {Pet} from '../../shared/models/pet';
import {CustomerService} from '../../shared/services/customer.service';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {
  customers: Pet[];


  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(petList => {
      this.customers = petList;
    });
  }

  delete(id: number) {
    this.customerService.deleteCustomer(id);
    // this.customers = this.customerService.getCustomers();
  }




}
