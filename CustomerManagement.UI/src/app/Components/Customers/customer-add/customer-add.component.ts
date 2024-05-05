import { Component, Inject, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { CustomerService } from '../../../services/customer.service';
import { Customer } from '../../../models/customer.model';
import { Router } from '@angular/router';

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

customerForm = this.formBuilder.group({
  fullName:['',Validators.required],
  dateOfBirth:["", Validators.required]

})

constructor(private customerService:CustomerService) {
  
  
}

Save(){
  console.log(this.customerForm.value);
  const customerToSave: Customer = {
    fullName:this.customerForm.value.fullName!,
    dateOfBirth:this.customerForm.value.dateOfBirth!,
  }

  this.customerService.createCustomer(customerToSave).subscribe(() => {
      console.log("Success");
      this.router.navigateByUrl ("/customer");
  })

}

}
