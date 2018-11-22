

import { Component, OnInit } from '@angular/core';
import {Schedule} from '../Schedulets'
import {ScheduleService} from '../schedule.service'
import { first } from 'rxjs/operators';
import{NotificationService} from '../notification.service'
import {ErrorParserService} from '../error-parser.service';
import { LoadingServiceService } from '../loading-service.service';

@Component({
  selector: 'app-sent-list',
  templateUrl: './sent-list.component.html',
  styleUrls: ['./sent-list.component.css']
})
export class SentListComponent implements OnInit {
  schedules : Schedule[]
  schedule : Schedule = new Schedule();
  constructor(private scheduleService : ScheduleService,
    public notificationservice : NotificationService,
    public errorParserService : ErrorParserService,
    private Loader : LoadingServiceService
    ) { }

  ngOnInit() {
   this.LoadList();
  }

  Delete(id: number){
  this.Loader.Start();
   this.scheduleService.Delete(id)
   .pipe(first())
   .subscribe(
   data => {
     this.Loader.Stop();
     this.notificationservice.Add('Deleted successfuly','success');
    this.LoadList();
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

  LoadList(){
    this.Loader.Start();
    this.scheduleService.SentList()
    .pipe()
    .subscribe(c=> {this.schedules = c; this.Loader.Stop();});
  }

}
