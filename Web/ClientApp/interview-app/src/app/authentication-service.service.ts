import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Config } from './Config';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  config: Config = new Config();

  constructor(private http: HttpClient) { }

  login(email: string, password: string, rememberme: boolean) {
    return this.http.post<any>(this.config.BaseUrl + "UserAuthentication", { email: email, password: password, rememberme: rememberme })
      .pipe(map(user => {
      
        if (user && user.token) {

          localStorage.setItem('currentUser', JSON.stringify(user));
        }

        return user;
      }));
  }

  logout() {
  
    localStorage.removeItem('currentUser');
  }
}
