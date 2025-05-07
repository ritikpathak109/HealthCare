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
  getPatientDetails(userId:any){
    return this.http.get(`http://localhost:5165/api/PatientDetails/Get-PatientDetails/${userId}`)
  }
  
  uploadProfilePicture(userId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);
  
    return this.http.post(`http://localhost:5165/api/PatientProfilePicture/Upload/${userId}`, formData);
  }
  getProfilePicture(userId: string) {
    return this.http.get(`http://localhost:5165/api/PatientProfilePicture/Get/${userId}`, {
      responseType: 'text'
    });
  }
  
  

  
}
