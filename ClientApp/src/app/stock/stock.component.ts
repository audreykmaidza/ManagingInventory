import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { stocksModel } from "../models/stocksModel";
import { goodsmovementsService } from "../goods-movements/goods-movements.service";
import { ProductsModel } from "../models/products.model";
import { storagelocationsModel } from "../models/storage-locations.model";

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {
  stocks: [stocksModel];
  idProdut: number;
  idStorage: number;
  Products: [ProductsModel];
  storagelocations: [storagelocationsModel];


  constructor(private goodsmovementsService: goodsmovementsService) { }

  ngOnInit() {
    this.idProdut = 0;
    this.idStorage = 0;
    this.GetAllStock();
    this.getAllProducts();    
    this.getAllStoragelocations(); 
    
  }


  GetAllStock()
  {
    this.goodsmovementsService.GetAllStock().subscribe(
      data=>{        
        this.stocks = data;
      },
      error=>{        
        console.log(error);        
      }
    )

  }

  GetStockByProductAndStorageLocation(sumit: NgForm)
  {
    this.idProdut = +sumit.value.idproduct;
    this.idStorage = +sumit.value.idstorageLocation;
    
    this.goodsmovementsService.GetStockByProductAndStorageLocation(+this.idProdut, +this.idStorage).subscribe(
      data=>{
        this.stocks = data;
        sumit.resetForm();
        
      },
      error=>{
        console.log(error);
        
      }
    )
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
