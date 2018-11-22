import { Component, OnInit, NgModule } from '@angular/core';
import {AuthenticationService} from '../authentication-service.service';

@NgModule()
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  collapse: boolean = true;
 
  constructor(private authenticationService: AuthenticationService, public auth: AuthenticationService) { }

  ngOnInit() {
    
  }
 
  LogOut(){
    this.authenticationService.logout();
  }
}
