import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../authentication-service.service';
import{NotificationService} from '../notification.service'
import {ErrorParserService} from '../error-parser.service';
import { LoadingServiceService } from '../loading-service.service';
@Component({ templateUrl: 'login.component.html', providers: [] })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  returnUrl: string;
  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private notificationService : NotificationService,
    private errorParserService : ErrorParserService,
    private Loader : LoadingServiceService
   ) { }

  ngOnInit() {
  
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberme:[true]
    });
  
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }

    this.Loader.Start();
   
    this.authenticationService.login(this.f.username.value, this.f.password.value, this.f.rememberme.value)
      .pipe(first())
      .subscribe(
      () => {
        this.Loader.Stop();
        },
      error => {
        switch(error.status){
          case 0 :
          this.notificationService.Add('web api loading error','danger');
          break;
          case 400 : 
          this.notificationService.Add(this.errorParserService.Parse(error.error),'warning');
          break;
          case 500 :
          this.notificationService.Add(this.errorParserService.Parse(error.error),'danger');
          break;
        }
        this.Loader.Stop();
        });
  }
}
