import { Customer } from '../models/customer.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  private baseUrl = 'https://localhost:7065';
  //http = Inject(HttpClient);
  constructor(private http: HttpClient) { 

  }

  public getAllCutomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseUrl + '/api/Customers');
  }

  public createCustomer(customer:Customer) {
      return this.http.post(this.baseUrl + "/api/Customers", customer);
  }
}
