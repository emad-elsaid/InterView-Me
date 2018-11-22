import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IntivatationListComponent } from './intivatation-list.component';

describe('IntivatationListComponent', () => {
  let component: IntivatationListComponent;
  let fixture: ComponentFixture<IntivatationListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IntivatationListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IntivatationListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
