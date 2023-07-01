import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import { storagelocationsModel } from "../models/storage-locations.model";



@Injectable({
  providedIn: 'root'
})
export class storagelocationsService {

  constructor(private http: HttpClient) {}  
  
  getAllstoragelocations(): Observable<storagelocationsModel> {
    return this.http.get<storagelocationsModel>('/StorageLocations/GetAllstoragelocations', {});
  }

  CreateStorageLocations(storagelocations:storagelocationsModel ): Observable<storagelocationsModel> {
    
    return this.http.post<storagelocationsModel>('/StorageLocations/CreateStorageLocations',storagelocations, {});
  }

  Updatestoragelocations(storagelocations:storagelocationsModel ): Observable<storagelocationsModel> {
    
    return this.http.post<storagelocationsModel>('/StorageLocations/UpdateStorageLocations',storagelocations, {});
  }

  Deletestoragelocations(storagelocations:storagelocationsModel ): Observable<storagelocationsModel> {
    
    return this.http.post<storagelocationsModel>('/StorageLocations/Deletestoragelocations',storagelocations, {});
  }
}
