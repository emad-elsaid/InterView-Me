import { Component, OnInit } from '@angular/core';
import {UserService} from '../user.service'
import { User } from '../User';
import { Schedule } from '../Schedulets';
import { ScheduleService } from '../schedule.service';
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-invite-user',
  templateUrl: './invite-user.component.html',
  styleUrls: ['./invite-user.component.css']
})
export class InviteUserComponent implements OnInit {
  users : User[]
  schedule : Schedule = new Schedule();
  constructor(private userservice : UserService,private scheduleService : ScheduleService) { }

  ngOnInit() {
    this.userservice.getAll()
    .pipe()
    .subscribe(c=> {
      console.log(c)
      this.users = c
    });
  }
 
  Invite(id:number){
    this.schedule.InvitedId = id;
   this.scheduleService.Create(this.schedule)
   .pipe(first())
   .subscribe(
   data => {
     alert('Done')
     },
   error => {
       alert(JSON.stringify(error.error))
     });
  }


}
