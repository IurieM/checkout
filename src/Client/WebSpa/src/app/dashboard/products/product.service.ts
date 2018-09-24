import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Product } from './product';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private catalogUrl = environment.api.catalog;

  constructor(private http: HttpClient) { }

  getProducts(category: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.catalogUrl}/product/category/${category}`);
  }
}
