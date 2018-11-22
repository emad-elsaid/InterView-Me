import { Component, OnInit, NgModule } from '@angular/core';
@NgModule()
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  Year : string;
  constructor() { }

  ngOnInit() {
    this.Year = new Date().getFullYear().toString();
  }

}
