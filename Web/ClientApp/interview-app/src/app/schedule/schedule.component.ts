import { Component, OnInit } from '@angular/core';
import { User } from '../User';
import { first } from 'rxjs/operators';
import { MenuItem } from 'primeng/api';
import { Schedule } from '../Schedulets';
import { ScheduleService } from '../schedule.service';
@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  private items: MenuItem[];
  schedules: Schedule[];
  cols: any[];
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit() {
    this.items = [
      { label: 'LogOut', url:'/Login' },
      { label: 'Users',url :'/Users' },
      { label: 'Invitations',url:'' },
      { label: 'Countries' },
      { label: 'Spain' },
      { label: 'F.C. Barcelona' },
      { label: 'Squad' },
      { label: 'Lionel Messi', url: 'https://en.wikipedia.org/wiki/Lionel_Messi' }
    ];

    this.loadAllschedules();
    this.cols = [
      { field: 'RequesterEmail', header: 'From' }
     
      
    ];

  }

  private loadAllschedules() {
    this.scheduleService.getAll().pipe(first()).subscribe(schedules => {
      this.schedules = schedules;
    });
  }

 
}
