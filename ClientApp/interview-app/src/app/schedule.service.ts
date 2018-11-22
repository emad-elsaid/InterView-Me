import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from './Config';
import { HttpHeaders } from '@angular/common/http';
import { Schedule } from './Schedulets';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  config: Config = new Config();
 

  constructor(private http: HttpClient) { }

  getAll() {
    
    return this.http.get<Schedule[]>(this.config.BaseUrl + "Schedule/RequestList",  {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + JSON.parse(localStorage.getItem("currentUser")).token
      })
    });
  }

  SentList() {
    
    return this.http.get<Schedule[]>(this.config.BaseUrl + "Schedule/SentList",  {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + JSON.parse(localStorage.getItem("currentUser")).token
      })
    });
  }

   Create(schedule : Schedule){
     return this.http.post(this.config.BaseUrl + 'Schedule',schedule, {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + JSON.parse(localStorage.getItem("currentUser")).token
      })
    });
   }

   Update(schedule : Schedule){
    return this.http.put(this.config.BaseUrl + 'Schedule',schedule, {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + JSON.parse(localStorage.getItem("currentUser")).token
      })
    });
  }

  Delete(id:number){
    return this.http.delete(this.config.BaseUrl + 'Schedule/' + id, {
      headers: new HttpHeaders({
        'Authorization': 'bearer ' + JSON.parse(localStorage.getItem("currentUser")).token
      })
    });
  }
}
