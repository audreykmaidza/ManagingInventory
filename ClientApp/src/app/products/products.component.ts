import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ProductsService } from './Products.service';
import { ProductsModel } from "../models/products.model";
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-Products',
  templateUrl: './Products.component.html',
  styleUrls: ['./Products.component.css']
})


export class ProductsComponent implements OnInit {  

  products: ProductsModel;
  itemToDelete: ProductsModel;
  modalRef: BsModalRef;

  constructor(private ProductsService: ProductsService,
              private router: Router,
              private modalService: BsModalService) { }

  ngOnInit() {
    this.getAllItem();
  }

  getAllItem()
  {
    this.ProductsService.getAllProducts().subscribe( 
      data => {
        this.products = data;
      } ,
      error => {        
            console.log("error");
      }
    );
  }

  edit(sumit: NgForm){
    if (sumit.valid) {
      var tempId = this.itemToDelete.idproduct;
      this.itemToDelete = sumit.value;
      this.itemToDelete.isDeleted = false;
      this.itemToDelete.idproduct = tempId;
      debugger;
      this.ProductsService.UpdateProducts(this.itemToDelete).subscribe( 
        data => { 
          this.getAllItem(); 
          this.modalRef.hide();      
        } ,
        error => {        
              console.log(error);
        }
      );
      
    }
  }

  delete(){
    this.ProductsService.DeleteProducts(this.itemToDelete).subscribe( 
      data => { 
        this.getAllItem();       
      } ,
      error => {        
            console.log(error);
      }
    );
  }
  create()
  {
    this.router.navigate(['Products/create']);
  }

  openModal(template: TemplateRef<any>, item: ProductsModel, type: string) {
    
    switch (type) {
      case "edit":
        this.modalRef = this.modalService.show(template, {class: 'modal-sm9'});
        break;
      case "delete":
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
        break;
    
      default:
        break;
    }
    
    this.itemToDelete = item;
  }
  confirm(): void {
    this.delete();
    this.modalRef.hide();
  }
 
  decline(): void {    
    this.modalRef.hide();
  }

}
