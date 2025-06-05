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
  getDoctorbySpecialization(specializationId:any){
    return this.http.get(`http://localhost:5165/api/DoctorbySpecialization/GetDoctorsBySpecilization/${specializationId}`)
  }
  getDoctorDetails(userId:any){
    return this.http.get(`http://localhost:5165/api/DoctorDetails/Get-DoctorDetails/${userId}`)
  }

  uploadDoctorProfilePicture(userId: string, file: File) {
    const formData = new FormData();
    formData.append('file', file);
  
    return this.http.post(`http://localhost:5165/api/DoctorProfilePicture/Upload/${userId}`, formData);
  }
  getDoctorProfilePicture(userId: string) {
    return this.http.get(`http://localhost:5165/api/DoctorProfilePicture/Get/${userId}`, {
      responseType: 'blob'
    });
  }
 
}
