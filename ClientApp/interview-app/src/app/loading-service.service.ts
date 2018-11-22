import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingServiceService {
 Loading : boolean = false;
  constructor() { }
  Start(){
    this.Loading = true;
  }

  Stop(){
   this.Loading = false;
  }
}
