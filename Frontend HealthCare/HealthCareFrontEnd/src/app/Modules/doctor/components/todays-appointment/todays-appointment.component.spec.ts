import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TodaysAppointmentComponent } from './todays-appointment.component';

describe('TodaysAppointmentComponent', () => {
  let component: TodaysAppointmentComponent;
  let fixture: ComponentFixture<TodaysAppointmentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TodaysAppointmentComponent]
    });
    fixture = TestBed.createComponent(TodaysAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
