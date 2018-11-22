import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { User } from '../User';
import { UserService } from '../user.service';

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
      private   router: Router
    

  ) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', [Validators.required, Validators.minLength(6)]],
      Gender: [true, Validators.required],
      PhoneNumber: ['', Validators.required]
    });
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
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
      
        
        });
  }
}
