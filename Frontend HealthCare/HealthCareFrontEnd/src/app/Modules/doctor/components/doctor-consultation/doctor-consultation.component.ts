import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-consultation',
  templateUrl: './doctor-consultation.component.html',
  styleUrls: ['./doctor-consultation.component.css']
})
export class DoctorConsultationComponent implements OnInit {

  constructor(private router: Router, private fb: FormBuilder) { }

   ngOnInit() {}

     consultationForm = this.fb.group({

       Tests: this.fb.array([
        this.fb.control(null)
      ])
        //  DoctorFirstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(3)]], 
        //  DoctorLastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'),  Validators.minLength(3)]],  
        //  UserName: ['', [Validators.required, Validators.minLength(3)]],  
        //  DoctorEmail: ['', [Validators.required, Validators.email, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$')]],  
        //  UserPassword: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]],  
        //  RoleId: ['', [Validators.required], ],
        //  DoctorDateOfBirth: ['', [Validators.required]],
        //  GenderId: ['', [Validators.required]],
        //  CountryId: ['', [Validators.required]],
        //  StateId: ['', [Validators.required]],
        //  DoctorAddress: ['', [Validators.required,  Validators.minLength(5)]],
        //  DoctorPhoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]], 
        //  SpecializationId: ['', [Validators.required]],
        //  ExperienceYears: ['', [Validators.required ]],       
       });


    addTest(): void {
    (this.consultationForm.get('Tests') as FormArray).push(
      this.fb.control(null)
    );


  }

  removeTest(index:any) {
    (this.consultationForm.get('Tests') as FormArray).removeAt(index);
  }


  getTestsFormControls(): AbstractControl[] {
    return (<FormArray> this.consultationForm.get('Tests')).controls
  }


   logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

}
