import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseApiUrl: string = 'https://localhost:7114';
  constructor(private http: HttpClient) { }

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseApiUrl + '/api/ProductAPI')
  }

  addProduct(addProductRequest: Product): Observable<Product> {
    return this.http.post<Product>(this.baseApiUrl + '/api/ProductAPI', addProductRequest)
  }

  deleteProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(this.baseApiUrl + '/api/ProductAPI/' + id);
  }
}
