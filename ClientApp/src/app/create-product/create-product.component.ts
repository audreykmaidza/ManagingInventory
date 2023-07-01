import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductsModel } from '../models/products.model';
import { ProductsService } from '../products/Products.service';

@Component({
  selector: 'app-create-Product',
  templateUrl: './create-Product.component.html',
  styleUrls: ['./create-Product.component.css']
})
export class CreateProductComponent implements OnInit {
  Products: ProductsModel;

  constructor(private ProductsService: ProductsService,
    private router: Router) { }

  ngOnInit() {
  }

  create(sumit: NgForm)
  {
    if(sumit.valid){
      this.Products = sumit.value;
      this.Products.isDeleted = false;
      debugger;
      this.ProductsService.createProducts(this.Products).subscribe(           
        data => {
          sumit.resetForm();
          this.goBack();
        } ,
        error => {        
              console.log(error);                   
        }
      );
      
    }

  }
  goBack()
  {
    this.router.navigate(['Products']);
  }

}
