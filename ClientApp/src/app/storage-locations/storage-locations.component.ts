import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { storagelocationsService } from './storage-locations.service';
import { storagelocationsModel } from "../models/storage-locations.model";
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-storage-locations',
  templateUrl: './storage-locations.component.html',
  styleUrls: ['./storage-locations.component.css']
})
export class StorageLocationsComponent implements OnInit {

  storagelocations: storagelocationsModel;
  itemToDelete: storagelocationsModel;
  modalRef: BsModalRef;

  constructor(private storagelocationsService: storagelocationsService,
              private router: Router,
              private modalService: BsModalService) { }

  ngOnInit() {
    this.getAllItem();
  }

  getAllItem()
  {
    this.storagelocationsService.getAllstoragelocations().subscribe( 
      data => {
        
        this.storagelocations = data;
      } ,
      error => {        
            console.log("error");
      }
    );
  }

  edit(sumit: NgForm){
    if (sumit.valid) {
      var tempId = this.itemToDelete.idstorageLocation;
      this.itemToDelete = sumit.value;
      this.itemToDelete.isDeleted = false;
      this.itemToDelete.idstorageLocation = tempId;
      debugger;
      this.storagelocationsService.Updatestoragelocations(this.itemToDelete).subscribe( 
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
    this.storagelocationsService.Deletestoragelocations(this.itemToDelete).subscribe( 
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
    this.router.navigate(['storage-locations/create']);
  }

  openModal(template: TemplateRef<any>, item: storagelocationsModel, type: string) {
    
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
