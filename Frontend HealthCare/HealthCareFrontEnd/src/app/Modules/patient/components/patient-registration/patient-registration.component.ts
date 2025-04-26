import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

  constructor(private fb: FormBuilder, private empreg: PatientServiceService,private route: Router) {}



  patitentRegisterForm = this.fb.group({
    PatientFirstName: ['', [Validators.required]],
    PatientLastName: ['', [Validators.required]],
    UserName: ['', [Validators.required]],
    UserEmail: ['', [Validators.required]],
    UserPassword: ['', [Validators.required]],
    RoleId: ['', [Validators.required]],
    DateofBirth: ['', [Validators.required]],
    GenderId: ['', [Validators.required]],
    CountryId: ['', [Validators.required]],
    StateId: ['', [Validators.required]],
    PatientAddress: ['', [Validators.required]],
    PatientPhoneNumber: ['', [Validators.required]],
 
  });
  ngOnInit() {
    this.loadCountries();
    this.patitentRegisterForm.get('CountryId')?.valueChanges.subscribe((countryId) => {
      if (countryId) {
        this.loadStates(countryId);
      }
    });
    this.loadRoles();
    this.loadGender();
  }


  loadCountries() {
    this.empreg.getCountires().subscribe((res) => {
      this.countries = res;
      console.log(this.countries);
    });
  }
  loadStates(countryId: any) {
    this.empreg.getStates(countryId).subscribe((res) => {
      this.states = res;
      console.log(this.states);
    });
  }
  onCountryChange(cid: any) {
    this.empreg.getStates(cid).subscribe((data) => {
      this.states = data;
    });
    console.log(this.states);
  }

  loadRoles() {
    this.empreg.getRoles().subscribe((res) => {
      this.roles = res;
      console.log(this.roles);
    });
  }
  loadGender() {
    this.empreg.getGenders().subscribe((res) => {
      this.gender = res;
      console.log(this.gender);
    });
  }
}
