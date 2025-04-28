import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientServiceService {

  constructor(private http: HttpClient) { }
  registerPatient(addUser:any){
    return this.http.post('http://localhost:5165/api/Patient/Register-Patient',addUser)
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
  loginUser(login:any){
    return this.http.post('http://localhost:5165/api/Login/LoginUser',login,{responseType:'text'})
  }

  
}
