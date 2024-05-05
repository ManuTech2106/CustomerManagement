import { Component } from '@angular/core';
import { Customer } from '../../../models/customer.model';
import { CustomerService } from '../../../services/customer.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { error } from 'console';

@Component({
  selector: 'app-customers-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './customers-list.component.html',
  styleUrl: './customers-list.component.css'
})

export class CustomersListComponent {

  customers: Customer[] = [];

  constructor(private customerService: CustomerService) {

  }

  ngOnInit() {

   this.getCustomers();
  }


  getCustomers() {

    this.customerService.getCutomers().subscribe(result => {
      this.customers = result;
      console.log(this.customers);
    });
  }
}
