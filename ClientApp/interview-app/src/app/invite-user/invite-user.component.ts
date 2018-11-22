import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service'
import { User } from '../User';
import { Schedule } from '../Schedulets';
import { ScheduleService } from '../schedule.service';
import { first } from 'rxjs/operators';
import{NotificationService} from '../notification.service'
import {ErrorParserService} from '../error-parser.service';
import { LoadingServiceService } from '../loading-service.service';
@Component({
  selector: 'app-invite-user',
  templateUrl: './invite-user.component.html',
  styleUrls: ['./invite-user.component.css']
})
export class InviteUserComponent implements OnInit {
  users : User[]
  schedule : Schedule = new Schedule();
  constructor(private userservice : UserService,
    private scheduleService : ScheduleService,
    public notificationservice : NotificationService,
    public errorParserService : ErrorParserService,
    private Loader : LoadingServiceService
    ) { }

  ngOnInit() {
    this.Loader.Start();
    this.userservice.getAll()
    .pipe()
    .subscribe(c=> {
      this.Loader.Stop();
      this.users = c
    });
  }
 
  Invite(id:number){
    this.Loader.Start();
    this.schedule.InvitedId = id;
   this.scheduleService.Create(this.schedule)
   .pipe(first())
   .subscribe(
   data => {
     this.Loader.Stop();
    this.notificationservice.Add('Invitation Created successfulty','success')
     },
   error => {
    switch(error.status){
      case 0 :
      this.notificationservice.Add('web api loading error','danger');
      break;
      case 400 : 
      this.notificationservice.Add(this.errorParserService.Parse(error.error),'warning');
      break;
      case 500 :
      this.notificationservice.Add(this.errorParserService.Parse(error.error),'danger');
      break;
    }
    this.Loader.Stop();
     });
  }


}
