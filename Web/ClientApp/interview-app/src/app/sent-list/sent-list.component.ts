

import { Component, OnInit } from '@angular/core';
import {Schedule} from '../Schedulets'
import {ScheduleService} from '../schedule.service'
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-sent-list',
  templateUrl: './sent-list.component.html',
  styleUrls: ['./sent-list.component.css']
})
export class SentListComponent implements OnInit {
  schedules : Schedule[]
  schedule : Schedule = new Schedule();
  constructor(private scheduleService : ScheduleService) { }

  ngOnInit() {
   this.LoadList();
  }

  Delete(id: number){
  
   this.scheduleService.Delete(id)
   .pipe(first())
   .subscribe(
   data => {
    this.LoadList();
     },
   error => {
       alert(JSON.stringify(error.error))
     });
  }

  LoadList(){
    this.scheduleService.getAll()
    .pipe()
    .subscribe(c=> {this.schedules = c});
  }

}
