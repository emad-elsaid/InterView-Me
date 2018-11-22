import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from './Config';
import { HttpHeaders } from '@angular/common/http';
import { Schedule } from './Schedulets';
const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'bearer ' + (JSON.parse(localStorage.getItem("currentUser")) != null ?
      JSON.parse(localStorage.getItem("currentUser")).token : "")
  })
}
@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  config: Config = new Config();
 

  constructor(private http: HttpClient) { }

  getAll() {
    
    return this.http.get<Schedule[]>(this.config.BaseUrl + "Schedule/RequestList", httpOptions);
  }

   Create(schedule : Schedule){
     return this.http.post(this.config.BaseUrl + 'Schedule',schedule,httpOptions);
   }

   Update(schedule : Schedule){
    return this.http.put(this.config.BaseUrl + 'Schedule',schedule,httpOptions);
  }

  Delete(id:number){
    return this.http.delete(this.config.BaseUrl + 'Schedule/' + id,httpOptions);
  }
}
