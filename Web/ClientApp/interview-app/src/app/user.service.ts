import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './User';
import { Config } from './Config';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'bearer ' + (JSON.parse(localStorage.getItem("currentUser")) != null ?
      JSON.parse(localStorage.getItem("currentUser")).token : "")
  })
}
@Injectable({
  providedIn: 'root'
})
export class UserService {
  config: Config = new Config();
  
  constructor(private http: HttpClient) { }

  CreateUser(user: User) {
    
    return this.http.post(this.config.BaseUrl + "user", user);
  }

  getAll() {
    return this.http.get<User[]>(this.config.BaseUrl + "user", httpOptions);
  }

}
