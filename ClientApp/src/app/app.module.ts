import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

import { AppComponent } from './app.component';
import {CoreModule} from "./core/core.module";
import {HomeComponent} from "./home/home.component";
import {LoginComponent} from "./login/login.component";
import {NavMenuComponent} from "./nav-menu/nav-menu.component";
import {Routing} from "./app.routing";

import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,
  
  
 
} from '@angular/material';
import {environment} from '../environments/environment';
import { ServiceWorkerModule } from '@angular/service-worker';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';
import { ProductsComponent } from './products/products.component';
import { StorageLocationsComponent } from './storage-locations/storage-locations.component';
import { GoodsMovementsComponent } from './goods-movements/goods-movements.component';
import { CreateProductComponent } from './create-Product/create-Product.component';
import { CreateStorageLocationComponent } from './create-storage-location/create-storage-location.component';
import { CreateGoodsMovementsComponent } from './create-goods-movements/create-goods-movements.component';
import { StockComponent } from './stock/stock.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    ProductsComponent,
    StorageLocationsComponent,
    GoodsMovementsComponent,
    CreateProductComponent,
    CreateStorageLocationComponent  ,
    NavMenuComponent,
    CreateGoodsMovementsComponent,
    StockComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    Routing,
    BrowserAnimationsModule,
    CoreModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatStepperModule,    
    ModalModule.forRoot(),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  entryComponents: [
    
  ],
  providers: [
    BsModalRef
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }