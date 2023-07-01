import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {LoginComponent} from "./login/login.component";
import {AuthorizatedGuard} from "./core/guards/authorizated.guard";
import { ProductsComponent } from './products/products.component';
import { StorageLocationsComponent } from './storage-locations/storage-locations.component';
import { GoodsMovementsComponent } from './goods-movements/goods-movements.component';
import { CreateProductComponent } from './create-Product/create-Product.component';
import { CreateStorageLocationComponent } from './create-storage-location/create-storage-location.component';
import { CreateGoodsMovementsComponent } from './create-goods-movements/create-goods-movements.component';
import { StockComponent } from './stock/stock.component';


const appRoutes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'Products', component: ProductsComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'storage-locations', component: StorageLocationsComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'storage-locations/create', component: CreateStorageLocationComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'goods-movements', component: GoodsMovementsComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'goods-movements/create', component: CreateGoodsMovementsComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'stock', component: StockComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'Products/create', component: CreateProductComponent, canActivate: [ AuthorizatedGuard ] },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home'},

];

export const Routing = RouterModule.forRoot(appRoutes);