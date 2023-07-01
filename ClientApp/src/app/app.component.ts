import { Component, OnInit  } from '@angular/core';
import {AuthenticationService} from "./login/shared/authentication.service";
import {StorageService} from "./core/services/storage.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [ AuthenticationService ]
})
export class AppComponent implements OnInit{
  
  
  constructor(private storageService: StorageService)
  {
  }
  ngOnInit()
  {
    
  }
  
}
