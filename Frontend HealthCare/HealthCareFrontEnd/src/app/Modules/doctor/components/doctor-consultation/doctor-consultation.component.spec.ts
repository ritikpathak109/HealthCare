import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorConsultationComponent } from './doctor-consultation.component';

describe('DoctorConsultationComponent', () => {
  let component: DoctorConsultationComponent;
  let fixture: ComponentFixture<DoctorConsultationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DoctorConsultationComponent]
    });
    fixture = TestBed.createComponent(DoctorConsultationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
