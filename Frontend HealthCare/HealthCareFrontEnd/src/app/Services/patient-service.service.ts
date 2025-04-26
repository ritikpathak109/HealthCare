import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientServiceService {

  constructor(private http: HttpClient) { }
  getPatients() {
    return this.http.get('http://localhost:5165/api/Patient/Register-Patient');
  }
  getCountires(){
    return this.http.get('http://localhost:5165/api/MasterTable/Get-Countries')
  }
  getStates(countryId:any){
    return this.http.get(`http://localhost:5165/api/MasterTable/Get-States/${countryId}`)
  }
  getRoles(){
    return this.http.get('http://localhost:5165/api/MasterTable/Get-Role')
  }
  getGenders(){
    return this.http.get('http://localhost:5165/api/MasterTable/Get-Gender')
  }

  
}
