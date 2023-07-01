import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import { goodsmovementsModel } from "../models/goods-movements.model";
import { goodsmovementsViewModel } from "../models/goodsmovementsViewModel";
import { movementTypesModel } from "../models/movementTypesModel";
import { ProductsModel } from "../models/products.model";
import { stocksModel } from "../models/stocksModel";
import { storagelocationsModel } from "../models/storage-locations.model";
import { User } from "../models/user.model";




@Injectable({
  providedIn: 'root'
})
export class goodsmovementsService {

  constructor(private http: HttpClient) {}  
  
  GetAllGoodsMovementsView(): Observable<goodsmovementsViewModel> {
    return this.http.get<goodsmovementsViewModel>('/goodsmovements/GetAllGoodsMovementsView', {});
  }

  CreateGoodsMovements(goodsmovements:goodsmovementsModel ): Observable<goodsmovementsModel> {
    
    return this.http.post<goodsmovementsModel>('/goodsmovements/CreateGoodsMovements',goodsmovements, {});
  }
  CreateStock(goodsmovements:goodsmovementsModel ): Observable<goodsmovementsModel> {
    
    return this.http.post<goodsmovementsModel>('/Stock/CreateStock',goodsmovements, {});
  }

  UpdateGoodsMovements(goodsmovements:goodsmovementsModel ): Observable<goodsmovementsModel> {
    
    return this.http.post<goodsmovementsModel>('/goodsmovements/UpdateGoodsMovements',goodsmovements, {});
  }

  DeleteGoodsMovements(goodsmovements:goodsmovementsModel ): Observable<goodsmovementsModel> {
    
    return this.http.post<goodsmovementsModel>('/goodsmovements/DeleteGoodsMovements',goodsmovements, {});
  }

  GetAllmovementTypes(): Observable<[movementTypesModel]> {
    return this.http.get<[movementTypesModel]>('/MovementTypes/GetAllMovementTypes', {});
  }

  GetAllProducts(): Observable<[ProductsModel]> {
    return this.http.get<[ProductsModel]>('/Products/GetAllProducts', {});
  }

  GetAllStock(): Observable<[stocksModel]> {
    return this.http.get<[stocksModel]>('/Stock/GetAllStock', {});
  }
  GetStockByProductAndStorageLocation(produt: number, storage: number): Observable<[stocksModel]> {
    return this.http.get<[stocksModel]>('/Stock/GetStockByProductAndStorageLocation/'+produt+"/"+storage, {});
  }

  GetAllStorageLocations(): Observable<[storagelocationsModel]> {
    return this.http.get<[storagelocationsModel]>('/StorageLocations/GetAllStorageLocations', {});
  }

  GetAllUsers(): Observable<[User]> {
    return this.http.get<[User]>('/Users/GetAllUsers', {});
  }
}
