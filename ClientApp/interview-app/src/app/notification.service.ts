import { Injectable } from '@angular/core';
import {NotificationModel} from './NotificationModel'
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  messages : NotificationModel[] = [];
  constructor() { }

  Add(message:string,type:string){
   
    this.messages.push({message,type});
    
  }

  clear(){
    this.messages = [];
  }
}
