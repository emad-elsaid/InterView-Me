import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../authentication-service.service';
@Component({ templateUrl: 'login.component.html', providers: [] })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  returnUrl: string;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
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
   
    this.authenticationService.login(this.f.username.value, this.f.password.value, this.f.rememberme.value)
      .pipe(first())
      .subscribe(
      data => {
        },
      error => {
          alert(JSON.stringify(error.error))
        });
  }
}
