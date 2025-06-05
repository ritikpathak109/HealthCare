import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorService } from 'src/app/Services/doctor.service';

@Component({
  selector: 'app-doctor-dashboard',
  templateUrl: './doctor-dashboard.component.html',
  styleUrls: ['./doctor-dashboard.component.css']
})
export class DoctorDashboardComponent implements OnInit {

userName: string | null = '';
roleName: string | null = '';
userId: string | null = '';
doctorDetails: any;
  profileImageUrl: string = '';
  imageUrl: string | ArrayBuffer | null = null;

selectedFile: File | null = null;
  constructor(private router: Router, private doctorService: DoctorService) { }



ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.roleName = localStorage.getItem('roleName');
    this.userId = localStorage.getItem('userId');

    if (this.userId) {
      this.loadDoctorDetails(this.userId);
      this.loadDoctorProfilePicture(this.userId);

    

    }
  }

  loadDoctorDetails(userId: string){
    this.doctorService.getDoctorDetails(userId).subscribe((res:any)=> {
      this.doctorDetails = res[0];
       localStorage.setItem('DoctorId', this.doctorDetails.doctorId);
      
    });
  }
  loadDoctorProfilePicture(userId: string) {
    this.doctorService.getDoctorProfilePicture(userId).subscribe(response => {
      const reader = new FileReader();
      reader.readAsDataURL(response);
      reader.onloadend = () => {
        this.imageUrl = reader.result;
      };
    });
    
  }
  
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }
  
  uploadPicture() {
    if (this.userId && this.selectedFile) {
      this.doctorService.uploadDoctorProfilePicture(this.userId, this.selectedFile).subscribe(() => {
        this.loadDoctorProfilePicture(this.userId!);
        alert('Profile picture uploaded successfully.');
        this.selectedFile = null;
        const fileInput = document.getElementById('fileInput') as HTMLInputElement;
        if (fileInput) {
          fileInput.value = ''; 
        }
      });
    }
  }

    logout(){

     localStorage.clear();
       this.router.navigate(['/login']);
  }

}
