import { Component, OnInit, NgModule } from '@angular/core';
import { LoadingServiceService } from '../loading-service.service';
@NgModule()
@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {

  constructor(public loader : LoadingServiceService) { }

  ngOnInit() {
  }

}
