import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalConsultationSlipComponent } from './final-consultation-slip.component';

describe('FinalConsultationSlipComponent', () => {
  let component: FinalConsultationSlipComponent;
  let fixture: ComponentFixture<FinalConsultationSlipComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FinalConsultationSlipComponent]
    });
    fixture = TestBed.createComponent(FinalConsultationSlipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
