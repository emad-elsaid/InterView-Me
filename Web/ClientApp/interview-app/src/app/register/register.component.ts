import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { User } from '../User';
import { UserService } from '../user.service';
import { MessageService } from 'primeng/components/common/messageservice';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [MessageService]
})
export class RegisterComponent implements OnInit {
  user: User;
  registerForm: FormGroup;
  submitted = false;
  Blocked = false;
  constructor(private userservice: UserService,
      private formBuilder: FormBuilder,
    private messageService: MessageService

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
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    }

    this.Blocked = true;
    this.userservice.CreateUser(this.registerForm.value)
      .pipe(first())
      .subscribe(
      data => {
        console.log(data)
        this.messageService.add({ severity: 'success', summary: 'Registered Successfuly', detail: '' });
        this.Blocked = false;
        },
      error => {
        if (error.status  === 400)
          this.messageService.add({ severity: 'warn', summary: 'something error', detail: '' });
        else
          this.messageService.add({ severity: 'error', summary: 'something error', detail: '' });
        this.Blocked = false;
        });
  }
}
