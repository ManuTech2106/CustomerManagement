import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/customer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  baseUrl: string = 'https://localhost:7065';

  constructor(private httpClient: HttpClient) {

  }

  public getCutomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>('https://localhost:7065/api/Customers');
  }
}
