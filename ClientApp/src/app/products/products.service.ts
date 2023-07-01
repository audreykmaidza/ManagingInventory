import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import { ProductsModel } from "../models/products.model";



@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) {}  
  
  getAllProducts(): Observable<ProductsModel> {
    return this.http.get<ProductsModel>('/Products/GetAllProducts', {});
  }

  createProducts(Products:ProductsModel ): Observable<ProductsModel> {
    
    return this.http.post<ProductsModel>('/Products/CreateProducts',Products, {});
  }

  UpdateProducts(Products:ProductsModel ): Observable<ProductsModel> {
    
    return this.http.post<ProductsModel>('/Products/UpdateProducts',Products, {});
  }

  DeleteProducts(Products:ProductsModel ): Observable<ProductsModel> {
    
    return this.http.post<ProductsModel>('/Products/DeleteProducts',Products, {});
  }
}
