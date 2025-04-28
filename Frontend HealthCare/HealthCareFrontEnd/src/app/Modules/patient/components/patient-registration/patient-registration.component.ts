import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PatientServiceService } from 'src/app/Services/patient-service.service';

@Component({
  selector: 'app-patient-registration',
  templateUrl: './patient-registration.component.html',
  styleUrls: ['./patient-registration.component.css']
})
export class PatientRegistrationComponent implements OnInit {

  selectedCountry: any;
  countries: any;
  states: any;
  roles: any;
  gender: any;

  constructor(private fb: FormBuilder, private patientregsrv: PatientServiceService, private route: Router, private toastr: ToastrService,) {}

  patientRegisterForm = this.fb.group({
    PatientFirstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(3)]], 
    PatientLastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'),  Validators.minLength(3)]],  
    UserName: ['', [Validators.required, Validators.minLength(3)]],  
    UserEmail: ['', [Validators.required, Validators.email, Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$')]],  
    UserPassword: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]],  
    RoleId: ['', [Validators.required]],
    DateofBirth: ['', [Validators.required]],
    GenderId: ['', [Validators.required]],
    CountryId: ['', [Validators.required]],
    StateId: ['', [Validators.required]],
    PatientAddress: ['', [Validators.required,  Validators.minLength(5)]],
    PatientPhoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]], 
  });

  ngOnInit() {
    this.loadCountries();
    this.patientRegisterForm.get('CountryId')?.valueChanges.subscribe((countryId) => {
      if (countryId) {
        this.loadStates(countryId);
      } else {
        this.states = [];
        this.patientRegisterForm.get('StateId')?.setValue('');
      }
    });

    this.loadRoles();
    this.loadGender();
  }

  onSubmit() {
    if (this.patientRegisterForm.valid) {
      console.log(this.patientRegisterForm.value);
      if (confirm('Do you want to register this employee? ')) {
        const formData= this.patientRegisterForm.value;
        this.patientregsrv.registerPatient(formData).subscribe((res) => {
          alert('Registration Successful!');
        this.patientRegisterForm.reset();
        });
      }
    } else {
      alert('Please fill Registration form correctly!');
    }
  }

  loadCountries() {
    this.patientregsrv.getCountires().subscribe((res) => {
      this.countries = res;
      console.log(this.countries);
    });
  }

  loadStates(countryId: any) {
    this.patientregsrv.getStates(countryId).subscribe((res) => {
      this.states = res;
     
    });
  }

  loadRoles() {
    this.patientregsrv.getRoles().subscribe((res) => {
      this.roles = res;
     
    });
  }

  loadGender() {
    this.patientregsrv.getGenders().subscribe((res) => {
      this.gender = res;
    
    });
  }
}
