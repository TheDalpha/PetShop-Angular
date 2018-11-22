import { Component, OnInit } from '@angular/core';
import {Pet} from '../../shared/models/pet';
import {CustomerService} from '../../shared/services/customer.service';
import {ActivatedRoute} from '@angular/router';
import {FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css']
})
export class CustomerDetailsComponent implements OnInit {
  customer: Pet;

  customerForm = new FormGroup({
    name: new FormControl(''),
    type: new FormControl(''),
    color: new FormControl(''),
    price: new FormControl('')
  });

  constructor( private route: ActivatedRoute,
    private customerService: CustomerService) {
  }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.customer = this.customerService.getCustomerById(id);
  }
}
