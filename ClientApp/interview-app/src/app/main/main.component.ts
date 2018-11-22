import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '../authentication-service.service';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(public auth : AuthenticationService) { }

  ngOnInit() {
   this.auth.get();
  }

}
