import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { User } from '../User';
import { UserService } from '../user.service';
import{NotificationService} from '../notification.service'
import {ErrorParserService} from '../error-parser.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
 
})
export class RegisterComponent implements OnInit {
  user: User;
  registerForm: FormGroup;
  submitted = false;

  constructor(private userservice: UserService,
      private formBuilder: FormBuilder,
      private   router: Router,
      private notificationService : NotificationService,
      private errorParserService : ErrorParserService
    

  ) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      Gender: [1, Validators.required],
      PhoneNumber: ['', Validators.required]
    });
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }

    this.userservice.CreateUser(this.registerForm.value)
      .pipe(first())
      .subscribe(
      data => {
        this.router.navigate(['/Login']);

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
        
        });
  }
}
