import { Component , OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';


import {StorageService} from "../core/services/storage.service";
import {User} from "../models/user.model";
import {AuthenticationService} from "../login/shared/authentication.service";



@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})


export class NavMenuComponent implements OnInit{

  public user: User;  
  
  modalRef: BsModalRef;
  message: string;

  constructor(
    private storageService: StorageService,
    private authenticationService: AuthenticationService,    
    private modalService: BsModalService
  ) { }

  ngOnInit() {
    this.user = this.storageService.getCurrentUser();
  }

  public logout(): void{
    this.authenticationService.logout().subscribe(
        response => {if(response) {this.storageService.logout();}}
    );
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {    
    this.isExpanded = !this.isExpanded;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {  
    this.logout();  
    this.modalRef.hide();
  }
 
  decline(): void {    
    this.modalRef.hide();
  }

  
}

