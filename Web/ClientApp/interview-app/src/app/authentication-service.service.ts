import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Config } from './Config';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  
  public loggedIn:boolean =   localStorage.getItem('currentUser') != null;

 
  config: Config = new Config();

  constructor(private http: HttpClient, private router: Router) { }

  login(email: string, password: string, rememberme: boolean) {
    return this.http.post<any>(this.config.BaseUrl + "UserAuthentication", { email: email, password: password, rememberme: rememberme })
      .pipe(map(user => {
      
        if (user && user.token) {
          this.loggedIn = true;
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.router.navigate(['/']);
        }

        return user;
      }));
  }

  logout() {
    this.loggedIn = false;
    this.router.navigate(['/Login']);
  }

  
}
