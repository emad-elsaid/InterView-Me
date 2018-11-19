import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../authentication-service.service';
import { MessageService } from 'primeng/components/common/messageservice';

@Component({ templateUrl: 'login.component.html', providers: [MessageService] })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  returnUrl: string;
  Blocked = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private messageService: MessageService
   ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberme:[true]
    });
    this.authenticationService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.Blocked = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value, this.f.rememberme.value)
      .pipe(first())
      .subscribe(
      data => {
        this.Blocked = false;
          this.router.navigate([this.returnUrl]);
          
        },
      error => {
        this.messageService.add({ severity: 'error', summary: error.error, detail: '' });

          this.Blocked = false;
        });
  }
}
