import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BookAppointmentService } from 'src/app/Services/book-appointment.service';
import { DoctorService } from 'src/app/Services/doctor.service';

@Component({
  selector: 'app-book-appointment',
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.css']
})
export class BookAppointmentComponent implements OnInit {

specialization: any;
doctors: any;
 constructor(private appservice: BookAppointmentService, private doctorService: DoctorService, private fb: FormBuilder) { }


 ngOnInit(){
  this.loadSpecialization();
  this.bookAppointmentForm.get('SpecializationId')?.valueChanges.subscribe((specializationId) => {
  if (specializationId) {
    this.loadDoctorsBySpecialization(specializationId);
  } 
  
});


 }

  bookAppointmentForm = this.fb.group({
      AppointmentDate: [null, Validators.required],
      SlotId: [null, Validators.required],
      ReasonForVisit: ['', [Validators.required]],
       DoctorId: ['', [Validators.required]],
      SpecializationId: ['', [Validators.required]],
     });

   loadSpecialization() {
    this.doctorService.getSpecialization().subscribe((res: any) => {
      this.specialization = res;
    });
  }
  loadDoctorsBySpecialization(specializationId: string) {
    this.doctorService.getDoctorbySpecialization(specializationId).subscribe((res: any) => {
      this.doctors = res;
    });
  }
}
