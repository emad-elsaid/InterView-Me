import { Component, OnInit } from '@angular/core';
import {Schedule} from '../Schedulets'
import {ScheduleService} from '../schedule.service'
import { first } from 'rxjs/operators';
import{NotificationService} from '../notification.service'
import {ErrorParserService} from '../error-parser.service';
import { LoadingServiceService } from '../loading-service.service';


@Component({
  selector: 'app-intivatation-list',
  templateUrl: './intivatation-list.component.html',
  styleUrls: ['./intivatation-list.component.css']
})
export class IntivatationListComponent implements OnInit {
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

  Update(id: number,status: boolean){
    this.Loader.Start();
   this.schedule.IsApporoved = status;
   this.schedule.id = id;
   this.scheduleService.Update(this.schedule)
   .pipe(first())
   .subscribe(
   data => {
     this.Loader.Stop();
     this.notificationservice.Add('updated successfulty','success')
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
     });
  }

  LoadList(){
    this.Loader.Start();
    this.scheduleService.getAll()
    .pipe()
    .subscribe(c=> {this.schedules = c; this.Loader.Stop()});
  }

}
