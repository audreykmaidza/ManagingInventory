import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { movementTypesModel } from "../models/movementTypesModel";
import { ProductsModel } from "../models/products.model";
import { storagelocationsModel } from "../models/storage-locations.model";
import { goodsmovementsModel } from "../models/goods-movements.model";
import { User } from "../models/user.model";
import { stocksModel } from "../models/stocksModel";
import { goodsmovementsService } from '../goods-movements/goods-movements.service';
import { StorageService } from '../core/services/storage.service';




@Component({
  selector: 'app-create-goods-movements',
  templateUrl: './create-goods-movements.component.html',
  styleUrls: ['./create-goods-movements.component.css']
})


export class CreateGoodsMovementsComponent implements OnInit {

  movementTypes: movementTypesModel [];
  Products: ProductsModel[]; 
  storagelocations: storagelocationsModel[];
  Users: User[];
  goodsmovements: goodsmovementsModel;
  user: User;
  stock: stocksModel;

 

  

  constructor(private Router: Router,
    private goodsmovementsService: goodsmovementsService,
    private StorageService: StorageService) { }

  ngOnInit() {
    this.getAllMovementTypes();
    this.getAllProducts();    
    this.getAllStoragelocations(); 
    this.GetCurrentUser();   
  }

  create(sumit: NgForm){
    
    if (sumit.valid) {
      sumit.value.idproduct = +sumit.value.idproduct
      this.goodsmovements = sumit.value;
      this.goodsmovements.isDeleted = false;  
      this.goodsmovements.date =  new Date();
      this.goodsmovements.idProduct =   +sumit.value.idproduct;      
      this.goodsmovements.idmovementType =  +sumit.value.idmovementType;
      this.goodsmovements.idstorageLocationFrom =  +sumit.value.idstorageLocationFrom;
      this.goodsmovements.idstorageLocationTo =  +sumit.value.idstorageLocationTo;
      this.goodsmovements.iduser =  +this.user.iduser;
      this.goodsmovements.quantity =  +sumit.value.quantity;


      this.goodsmovementsService.CreateGoodsMovements(this.goodsmovements).subscribe( 
        data => { 
          sumit.resetForm();
          this.createStock();
        } ,
        error => {    
              
              console.log(error);
        }
      );
      
    }
  }

  createStock()
  {
    this.goodsmovementsService.CreateStock (this.goodsmovements).subscribe( 
      data => {         
        this.goBack();
      } ,
      error => {    
            
            console.log(error);
      }
    );

  }

  GetCurrentUser()
  {
    this.user = this.StorageService.getCurrentUser();
     
  }

  goBack()
  {
    this.Router.navigate(['goods-movements']);
  }

  getAllMovementTypes()
  {
    this.goodsmovementsService.GetAllmovementTypes().subscribe( 
      data => {
        this.movementTypes = data;
        
      } ,
      error => {        
            console.log(error);
      }
    );
  }

  getAllProducts()
  {
    this.goodsmovementsService.GetAllProducts().subscribe( 
      data => {
        this.Products = data;
        
      } ,
      error => {        
            console.log(error);
      }
    );
  } 

  getAllStoragelocations()
  {
    this.goodsmovementsService.GetAllStorageLocations().subscribe( 
      data => {
        this.storagelocations = data;
        
      } ,
      error => {        
            console.log(error);
      }
    );
  }

  

}
