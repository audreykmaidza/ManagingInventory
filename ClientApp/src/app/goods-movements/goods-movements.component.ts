import { Component, OnInit, TemplateRef } from '@angular/core';
import { goodsmovementsService } from './goods-movements.service';
import { goodsmovementsViewModel } from "../models/goodsmovementsViewModel";
import { Router } from '@angular/router';


@Component({
  selector: 'app-goods-movements',
  templateUrl: './goods-movements.component.html',
  styleUrls: ['./goods-movements.component.css']
})
export class GoodsMovementsComponent implements OnInit {

  goodsmovements: goodsmovementsViewModel; 

  constructor(private goodsmovementsService: goodsmovementsService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.getAllItem();    
  }

  create()
  {
    this.router.navigate(['goods-movements/create']);
  }
 

  getAllItem()
  {
    this.goodsmovementsService.GetAllGoodsMovementsView().subscribe( 
      data => {
        this.goodsmovements = data;       
        
      } ,
      error => {        
            console.log(error);
      }
    );
  }



 

}
