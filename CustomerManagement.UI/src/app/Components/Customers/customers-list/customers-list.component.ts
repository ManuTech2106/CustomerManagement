import { Component, inject } from '@angular/core';
import { CustomerService } from '../../../services/customer.service';
import { CommonModule } from '@angular/common';
import { AsyncPipe } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import { Customer } from '../../../models/customer.model';
import { MatButton } from '@angular/material/button';
import { RouterLink, Router} from '@angular/router';
import { AgePipe } from '../../../Pipes/age.pipe';


@Component({
    selector: 'app-customers-list',
    standalone: true,
    templateUrl: './customers-list.component.html',
    styleUrl: './customers-list.component.css',
    imports: [CommonModule, AsyncPipe, MatTableModule, MatButton, RouterLink, AgePipe]
})

export class CustomersListComponent {

  customers: Customer[] = [];
  constructor(private customerService: CustomerService) {

  }

  router = inject(Router);
   
  customerData$ = this.customerService.getAllCutomers();

  displayedColumns: string[] = ['Customer Id', 'Full Name', 'Date Of Birth', 'Age', 'Action'];
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

  editCustomer(customerId:string) {
      this.router.navigateByUrl("/customer/" + customerId);
  }  

}
