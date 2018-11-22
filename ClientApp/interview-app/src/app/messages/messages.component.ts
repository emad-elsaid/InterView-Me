import { Component, OnInit, NgModule } from '@angular/core';
import{NotificationService} from '../notification.service'
@NgModule()
@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  constructor(public notification :NotificationService ) {
    
   }

  ngOnInit() {
  }

  Clear(){
    this.Clear();
  }
}
