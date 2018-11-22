import { Component, OnInit } from '@angular/core';
import {Pet} from '../../shared/models/pet';
import {CustomerService} from '../../shared/services/customer.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css']
})
export class CustomersListComponent implements OnInit {
  customers: Pet[];


  constructor(private customerService: CustomerService, private router: Router) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(petList => {
      this.customers = petList;
    });
  }

  delete(id: number) {
    this.customerService.deleteCustomer(id)
      .subscribe(message => {
        console.log('Deleted user, got message: ' + message), window.location.reload();
      });
    // this.customers = this.customerService.getCustomers();
  }




}
