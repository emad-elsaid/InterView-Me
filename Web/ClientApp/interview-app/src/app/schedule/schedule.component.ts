import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Schedule } from '../Schedulets';
import { ScheduleService } from '../schedule.service';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  schedules: Schedule[];
  cols: any[];
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit() {
  

    this.loadAllschedules();
    this.cols = [
      { field: 'RequesterEmail', header: 'Email' },
      { field: 'RequesterName', header: 'Name' },
      { field: 'IsApporoved', header: 'Approved' }

      
    ];

  }

  private loadAllschedules() {
    this.scheduleService.getAll().pipe(first()).subscribe(schedules => {
      this.schedules = schedules;
    });
  }

  Accept(schedule: Schedule) {
    
  }
 
}
