import { Routes } from '@angular/router';
import { CustomersListComponent } from './Components/Customers/customers-list/customers-list.component';
import { CustomerAddComponent } from './Components/Customers/customer-add/customer-add.component';

export const routes: Routes = [
{
    path:'',
    component: CustomersListComponent
}, 
{
    path:'customer',
    component: CustomersListComponent
},
{
    path:'add-customer',
    component: CustomerAddComponent
}

    
];
