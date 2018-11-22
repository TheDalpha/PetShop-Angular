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
    name: new FormControl(''),
    type: new FormControl(''),
    color: new FormControl(''),
    price: new FormControl('')
  });

  constructor(private customerService: CustomerService,
  private router: Router) { }

  ngOnInit() {
  }

  save() {
    const customer = this.customerForm.value;
    this.customerService.addCustomer( customer )
      .subscribe(() => {
        this.router.navigateByUrl('/customers');
      });
    /*this.customerForm.reset();
    this.router.navigateByUrl('/customers');*/
  }
}
