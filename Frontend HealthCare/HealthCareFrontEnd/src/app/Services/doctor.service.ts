import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http: HttpClient) { }

  registerDoctor(data: any) {
    return this.http.post('http://localhost:5165/api/DoctorRegistration/Register-Doctor', data);
  }

  getSpecialization() {
    return this.http.get('http://localhost:5165/api/MasterTable/Get-DoctorSpecialization');
  }
 getCountires(){
    return this.http.get('http://localhost:5165/api/MasterTable/Get-Countries')
  }
  getStates(countryId:any){
    return this.http.get(`http://localhost:5165/api/MasterTable/Get-States/${countryId}`)
  }
  getGenders(){
    return this.http.get('http://localhost:5165/api/MasterTable/Get-Gender')
  }
  
}
