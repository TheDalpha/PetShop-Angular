import {Component, OnInit} from '@angular/core';
import {Pet} from '../models/pet';
import {AuthenticationService} from '../services/authentication.service';
import {CustomerService} from '../services/customer.service';

@Component({
  //moduleId: module.id,
  templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {
  todoitems: Pet[] = [];
  username: string;
  errormessage: string = '';

  constructor(private todoItemService: CustomerService, private authService: AuthenticationService) {
    this.username = authService.getUsername();
  }

  ngOnInit() {
    // get users from secure api end point
    this.todoItemService.getCustomers()
      .subscribe(
        items => {
          this.todoitems = items;
        },
        error => {
          this.errormessage = error.message;
        });
  }

}
