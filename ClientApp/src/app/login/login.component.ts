import {Component, OnInit} from "@angular/core";
import { NgForm } from '@angular/forms';
import {LoginObject} from "./shared/login-object.model";
import {AuthenticationService} from "./shared/authentication.service";
import {StorageService} from "../core/services/storage.service";
import {Router} from "@angular/router";
import {User} from "../models/user.model";
import { sha256 } from 'js-sha256';



@Component({
  selector: 'login',
  templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
 
  noLogin:boolean = false;

  constructor(private authenticationService: AuthenticationService,
              private storageService: StorageService,
              private router: Router) { }

  ngOnInit() {
  
  }

  public submitLogin(sumit: NgForm) { 
    this.noLogin = false; 
    var encript : string = sumit.value.password;
    encript = sha256(encript);    
    sumit.value.password = encript;
    if(sumit.valid){
      this.authenticationService.login(new LoginObject(sumit.value)).subscribe(        
        data => {          
          if (data != null) {
            this.correctLogin(data);            
          }
          else{
            this.noLogin = true;
          }
        },
        error => { 
          this.noLogin = true; 
          console.log(error);
        }
      )
    }
  }

  private correctLogin(data: User){    
    this.storageService.setCurrentSession(data);
    this.router.navigate(['/home']);
  }
}