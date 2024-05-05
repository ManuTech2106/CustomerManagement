import { Component, Inject, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { CustomerService } from '../../../services/customer.service';
import { Customer } from '../../../models/customer.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Console } from 'console';

@Component({
  selector: 'app-customer-add',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule, MatDatepickerModule],
  templateUrl: './customer-add.component.html',
  styleUrl: './customer-add.component.css'
})
export class CustomerAddComponent {
  formBuilder = inject(FormBuilder);
  //customerService= Inject(CustomerService)
  router = inject(Router);
  activatedRoute = inject(ActivatedRoute);

  customerForm = this.formBuilder.group({
    fullName: ['', Validators.required],
    dateOfBirth: ["", Validators.required]

  })

  constructor(private customerService: CustomerService) { }

  customerId!: string;

  isUpdate = false;
  action = "Create";
  ngOnInit() {
    this.customerId = this.activatedRoute.snapshot.params['customerId'];

    if (this.customerId) {
      this.isUpdate = true;
      this.action = "Update";
      this.customerService.getCustomer(this.customerId).subscribe(result => {
        console.log(result);
        this.customerForm.patchValue(result);
      })
    }

  }

  Save() {
    console.log(this.customerForm.value);
    const customerToSave: Customer = {
      fullName: this.customerForm.value.fullName!,
      dateOfBirth: this.customerForm.value.dateOfBirth!,
    }

    this.customerService.createCustomer(customerToSave).subscribe(() => {
      console.log("Success");
      this.router.navigateByUrl("/customer");
    })

  }

  Update() {
    console.log(this.customerForm.value);
    console.log("Update Customer - this is in progress");
    alert("Update Customer - this is in progress");
    
    // const customerToSave:object = {
    //   customerId: this.customerId,
    //   fullName: this.customerForm.value.fullName,
    //   //dateOfBirth: this.customerForm.value.dateOfBirth!,
    // }

    // this.customerService.updateCustomer(this.customerId, customerToSave).subscribe(() => {
    //   console.log("Update Customer");
    //   this.router.navigateByUrl("/customer");
    // })

  }

}
