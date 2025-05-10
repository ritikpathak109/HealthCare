import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DoctorService } from 'src/app/Services/doctor.service';

@Component({
  selector: 'app-doctor-registration',
  templateUrl: './doctor-registration.component.html',
  styleUrls: ['./doctor-registration.component.css']
})
export class DoctorRegistrationComponent implements OnInit {

specialization: any;
 countries: any;
  states: any;
  gender: any;

  constructor(private fb: FormBuilder, private doctorService: DoctorService, private route: Router) { }

    doctorRegisterForm = this.fb.group({
      DoctorFirstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(3)]], 
      DoctorLastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'),  Validators.minLength(3)]],  
      UserName: ['', [Validators.required, Validators.minLength(3)]],  
      DoctorEmail: ['', [Validators.required, Validators.email, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$')]],  
      UserPassword: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]],  
      RoleId: ['', [Validators.required], ],
      DoctorDateOfBirth: ['', [Validators.required]],
      GenderId: ['', [Validators.required]],
      CountryId: ['', [Validators.required]],
      StateId: ['', [Validators.required]],
      DoctorAddress: ['', [Validators.required,  Validators.minLength(5)]],
      DoctorPhoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]], 
    
    });
  ngOnInit() {
    
    this.loadSpecialization();
    this.loadCountries();
     this.doctorRegisterForm.get('CountryId')?.valueChanges.subscribe((countryId) => {
      if (countryId) {
        this.loadStates(countryId);
      } else {
        this.states = [];
        this.doctorRegisterForm.get('StateId')?.setValue('');
      }
    });
    this.loadGender();
  
    
  }

  loadSpecialization() {
    this.doctorService.getSpecialization().subscribe((res: any) => {
      this.specialization = res;
    });
  }

   loadCountries() {
    this.doctorService.getCountires().subscribe((res) => {
      this.countries = res;
      console.log(this.countries);
    });
  }

  loadStates(countryId: any) {
    this.doctorService.getStates(countryId).subscribe((res) => {
      this.states = res;
      console.log(this.states);
     
    });
  }

 
  loadGender() {
    this.doctorService.getGenders().subscribe((res) => {
      this.gender = res;
    
    });
  }
}
