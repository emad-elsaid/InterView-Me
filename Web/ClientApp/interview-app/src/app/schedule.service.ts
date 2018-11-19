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

}
