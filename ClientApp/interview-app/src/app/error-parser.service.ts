import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorParserService {
  message : string = '';
  constructor() { }

  Parse (error : object) : string{
    if(error instanceof String){
      this.message = error.toString();
    }
    else{
      Object.values(error).forEach(value => {
        this.message += value;
      });

    }
    return this.message;
  }
}
