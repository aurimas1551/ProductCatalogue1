import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductType } from '../models/productType.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductTypesService {
  baseApiUrl: string = 'https://localhost:7114';
  constructor(private http: HttpClient) { }

  getAllProductTypes(): Observable<ProductType[]> {
    return this.http.get<ProductType[]>(this.baseApiUrl + '/api/ProductTypeAPI')
  }
}
