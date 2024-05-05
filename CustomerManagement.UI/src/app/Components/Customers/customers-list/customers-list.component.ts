import { Component } from '@angular/core';
import { CustomerService } from '../../../services/customer.service';
import { CommonModule } from '@angular/common';
import { AsyncPipe } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import { Customer } from '../../../models/customer.model';

@Component({
  selector: 'app-customers-list',
  standalone: true,
  imports: [CommonModule, AsyncPipe, MatTableModule],
  templateUrl: './customers-list.component.html',
  styleUrl: './customers-list.component.css'
})

export class CustomersListComponent {

  customers: Customer[] = [];
  constructor(private customerService: CustomerService) {

  }
   
  customerData$ = this.customerService.getAllCutomers();

  displayedColumns: string[] = ['Customer Id', 'Full Name', 'Date Of Birth'];
  dataSource = this.customers;

  ngOnInit() {
   this.getCustomers();
  }


  getCustomers() {
    this.customerService.getAllCutomers().subscribe(result => {
      this.customers = result;
      console.log(this.customers);
      this.dataSource = this.customers;

    });
  }
}
