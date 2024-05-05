import { Routes } from '@angular/router';
import { CustomersListComponent } from './Components/Customers/customers-list/customers-list.component';

export const routes: Routes = [
{
    path:'',
    component: CustomersListComponent
}, 
{
    path:'customer',
    component: CustomersListComponent
}
    
];
