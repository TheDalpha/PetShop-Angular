import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../../shared/services/customer.service';
import {FormControl, FormGroup} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {

  customerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    address: new FormControl('')
  });

  constructor(private customerService: CustomerService,
  private router: Router) { }

  ngOnInit() {
  }

  save() {
    const customer = this.customerForm.value;
    this.customerService.addCustomer( customer );
    this.customerForm.reset();
    this.router.navigateByUrl('/customers');
  }
}
