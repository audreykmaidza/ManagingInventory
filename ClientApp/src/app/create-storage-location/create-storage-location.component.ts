import { Component, OnInit } from '@angular/core';
import { storagelocationsService } from '../storage-locations/storage-locations.service';
import { storagelocationsModel } from "../models/storage-locations.model";
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create-storage-location',
  templateUrl: './create-storage-location.component.html',
  styleUrls: ['./create-storage-location.component.css']
})
export class CreateStorageLocationComponent implements OnInit {

  storagelocations: storagelocationsModel;

  constructor(private storagelocationsService: storagelocationsService,
              private Router: Router) { }

  ngOnInit() {
  }

  create(sumit: NgForm){   
    if (sumit.valid) {
      this.storagelocations = sumit.value;
      this.storagelocations.isDeleted = false;   

      this.storagelocationsService.CreateStorageLocations(this.storagelocations).subscribe( 
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
    this.Router.navigate(['storage-locations']);
  }

}
