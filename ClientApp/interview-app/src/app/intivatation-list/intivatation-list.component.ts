import { Component, OnInit } from '@angular/core';
import {Schedule} from '../Schedulets'
import {ScheduleService} from '../schedule.service'
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-intivatation-list',
  templateUrl: './intivatation-list.component.html',
  styleUrls: ['./intivatation-list.component.css']
})
export class IntivatationListComponent implements OnInit {
  schedules : Schedule[]
  schedule : Schedule = new Schedule();
  constructor(private scheduleService : ScheduleService) { }

  ngOnInit() {
   this.LoadList();
  }

  Update(id: number,status: boolean){
   this.schedule.IsApporoved = status;
   this.schedule.id = id;
   this.scheduleService.Update(this.schedule)
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
